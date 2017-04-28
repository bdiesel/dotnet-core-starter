using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestApp.Entities;
using TestApp.Services;
using TestApp.ViewModels;
using SaasKit.Multitenancy;

namespace TestApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IDataEntityData _dataEntityData;
        private IGreeter _greeter;
        private AppTenant _tenant;

        public HomeController(IDataEntityData dataEntityData, IGreeter greeter, AppTenant tenant)
        {
            _dataEntityData = dataEntityData;
            _greeter = greeter;
            _tenant = tenant;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            model.DataEntites = _dataEntityData.GetAll();
            model.CurrentMessage = _greeter.GetGreeting();
            return View(model);
        }

 
        public IActionResult Details(int id)
        {
            var model = _dataEntityData.Get(id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _dataEntityData.Get(id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DataEntityEditViewModel model)
        {
            var dataEntity = _dataEntityData.Get(id);
            if (ModelState.IsValid)
            {
                dataEntity.Cuisine = model.Cuisine;
                dataEntity.Name = model.Name;

                return RedirectToAction("Details", new { id = dataEntity.Id });
            }
            return View(dataEntity);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DataEntityEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newDataEntity = new DataEntity();
                newDataEntity.Cuisine = model.Cuisine;
                newDataEntity.Name = model.Name;

                newDataEntity = _dataEntityData.Add(newDataEntity);

                return RedirectToAction("Details", new { id = newDataEntity.Id });
            }
            else
            {
                return View();
            }
        }
    }
}

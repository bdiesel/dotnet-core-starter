using Microsoft.AspNetCore.Mvc;
using TestApp.Entities;
using TestApp.Services;
using TestApp.ViewModels;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        private IDataEntityData _dataEntityData;
        private IGreeter _greeter;

        public HomeController(IDataEntityData dataEntityData, IGreeter greeter)
        {
            _dataEntityData = dataEntityData;
            _greeter = greeter;
        }

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

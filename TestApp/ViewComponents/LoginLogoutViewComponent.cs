using Microsoft.AspNetCore.Mvc;


namespace TestApp.ViewComponents
{
    public class LoginLogoutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

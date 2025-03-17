using Microsoft.AspNetCore.Mvc;

namespace viewsExample.controllers
{
    public class HomeController : Controller  //view name should be same as the controller name
    {
        [Route("home")]
        public IActionResult Index()
        {
            return View("abc");
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace test01MVC.Controllers
{
    public class About : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

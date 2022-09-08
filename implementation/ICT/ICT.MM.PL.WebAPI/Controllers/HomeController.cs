using Microsoft.AspNetCore.Mvc;

namespace ICT.MM.PL.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

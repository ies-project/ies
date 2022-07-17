using Microsoft.AspNetCore.Mvc;

namespace ICT.MM.PL.WebAPI.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

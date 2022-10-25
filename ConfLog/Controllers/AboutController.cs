using Microsoft.AspNetCore.Mvc;

namespace ConfLog.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            HttpContext.Session.Clear();
            return View();
        }
    }
}

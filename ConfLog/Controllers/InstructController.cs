using Microsoft.AspNetCore.Mvc;

namespace ConfLog.Controllers
{
    public class InstructController : Controller
    {
        public IActionResult Instruct()
        {
            HttpContext.Session.Clear();
            return View();
        }
    }
}

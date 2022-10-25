using ConfLog.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConfLog.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Form()
        {
            ViewBag.Fu = string.Join('!', GetCart().listFuncs.Where(p => (!p.isBase)).Select(r=>r.name).ToArray());
            Console.WriteLine(ViewBag.Fu);
           
            return View();
        }
        [HttpPost]
        public IActionResult Form(ConstructorDetails tmp)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.Set("Constructor", tmp);
                return RedirectToActionPermanent("Text", "Text");
            }
            if (ModelState.ErrorCount==1)
            {
                if (!GetCart().listFuncs.Select(p => p.name).ToList().Contains("Tcp"))
                {
                    if (String.IsNullOrEmpty(tmp.Tcp))
                    {
                        HttpContext.Session.Set("Constructor", tmp);
                        return RedirectToActionPermanent("Text", "Text");
                    }
                }
                   
                
            }
            ViewBag.Fu = string.Join('!', GetCart().listFuncs.Where(p => (!p.isBase)).Select(r => r.name).ToArray());
            return View(tmp);

        }
        public ActionResult Home()
        {
            return RedirectToAction("Write", "Write");
        }
        public CartFuncs GetCart()
        {
            CartFuncs cart = HttpContext.Session.Get<CartFuncs>("Cart");
            if (cart == null)
            {
                cart = new CartFuncs();
                HttpContext.Session.Set("Cart", cart);
            }

            return cart;
        }
        public ConstructorDetails GetCons()
        {
            ConstructorDetails cart = HttpContext.Session.Get<ConstructorDetails>("Constructor");
            if (cart == null)
            {
                cart = new ConstructorDetails();
                HttpContext.Session.Set("Constructor", cart);
            }

            return cart;
        }

    }
    
}

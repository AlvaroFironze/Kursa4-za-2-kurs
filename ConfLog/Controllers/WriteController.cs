using ConfLog.Interfaces;
using ConfLog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConfLog.Controllers
{
    public class WriteController : Controller
    {
        private readonly AppDBContent _appDBcontent;
        private readonly IAllFuncs _allFuncs;
        private readonly IFuncType _funcTypes;

        public WriteController(IAllFuncs allFuncs, IFuncType funcTypes, AppDBContent appDBcontent)
        {
            _appDBcontent = appDBcontent;
            _allFuncs = allFuncs;
            _funcTypes = funcTypes;
        }
        public ViewResult Write()
        {
            CartFuncs tmp = GetCart();
            
            List<Function> obect = new List<Function>();
            tmp.listFuncs.ForEach(p => obect.Add(_allFuncs.getObjectFunc(p.id)));
            tmp.listFuncs = obect;
            List<Function> Funcs = new List<Function>(tmp.listFuncs.Where(p => p.typeID == 2));
            tmp.listFuncs=(tmp.listFuncs.Where(p => p.typeID ==1).ToList());
            tmp.listFuncs.ForEach(p => p.type = null);
            tmp.listFuncs.ForEach(p => p.fields = null);
            HttpContext.Session.Set("Cart", tmp);
            ViewBag.Title = "Выберем функции вам нужны";
            ViewBag.Bu = _allFuncs.getNonBaseFuncs.Where(i => i.typeID == 2);
            ViewBag.Fe = _allFuncs.getBaseFuncs.Where(i => i.typeID == 2);
            List<CartItem> selectedFuncs1 = new List<CartItem>();
            if (Funcs.Count != 0)
            {
                foreach (var ff in ViewBag.Bu)
                {
                    if (Funcs.Select(p => p.name).ToList().Contains(ff.name))
                    {
                        selectedFuncs1.Add(tmp.NewItem(ff, true));
                    }
                    else selectedFuncs1.Add(tmp.NewItem(ff, false));
                }

            }
            else
                foreach (var ff in ViewBag.Bu)
            {
                selectedFuncs1.Add(tmp.NewItem(ff));

            }
            return View(selectedFuncs1);
        }
        [HttpPost]
        public IActionResult Result(List<CartItem> selectedFuncs1)
        {
            CartFuncs tmp = GetCart();
            foreach (var ff in _allFuncs.getBaseFuncs.Where(i => i.typeID == 2))
            {
                tmp.AddtoCart(ff);
            }
            foreach (var ff in selectedFuncs1.Where(p => p.Checked))
            {
                tmp.AddtoCart(ff.func);
            }
            foreach (var ff in tmp.listFuncs)
            {
                Console.WriteLine(ff.name);
            }
            HttpContext.Session.Set("Cart", tmp);
            List<Function> Fres = new List<Function>();
            tmp.listFuncs.ForEach(p => Fres.Add(_allFuncs.getObjectFunc(p.id)));
            if (Fres.Where(i => i.typeID == 2).Where(t=>t.name!="Database").Where(r => !r.isBase).Any())
            {
                return RedirectToActionPermanent("Form", "Form");
            }
            return RedirectToActionPermanent("Text", "Text");


        }

        public ActionResult Home()
        {         
            return RedirectToAction("List", "Level");
        }
            public CartFuncs GetCart()
        {

            CartFuncs cart = HttpContext.Session.Get<CartFuncs>("Cart");
            if (cart == null)
            {
                Console.WriteLine("null");
                cart = new CartFuncs();
                HttpContext.Session.Set("Cart", cart);
            }
            else
            {
                Console.WriteLine("NEnull");
            }
            return cart;
        }

    }
}

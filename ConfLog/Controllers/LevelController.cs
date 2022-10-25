using ConfLog.Interfaces;
using ConfLog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Text.Json;

namespace ConfLog.Controllers
{
    public class LevelController: Controller
    {
        private readonly AppDBContent _appDBcontent;
        private readonly IAllFuncs _allFuncs;
        private readonly IFuncType _funcTypes;

        public LevelController(IAllFuncs allFuncs, IFuncType funcTypes, AppDBContent appDBcontent)
        {
            _appDBcontent = appDBcontent;
            _allFuncs = allFuncs;
            _funcTypes = funcTypes;
        }
        public ActionResult List()
        {            
            CartFuncs tmp = GetCart();
            List<Function> Funcs = new List<Function>(tmp.listFuncs);
            HttpContext.Session.Clear();
            ViewBag.Title = "Выбираем глубину логирования";
            ViewBag.Fu= _allFuncs.getBaseLogFuncs.Where(i => i.typeID==1);
            ViewBag.Bu = _allFuncs.getNonBaseLogFuncs.Where(i => i.typeID == 1).ToList();
            List < CartItem > selectedFuncs= new List<CartItem>();
            if (Funcs.Count != 0)
            {
                foreach (var ff in ViewBag.Bu)
                {
                    if (Funcs.Select(p => p.name).ToList().Contains(ff.name))
                    {
                        selectedFuncs.Add(tmp.NewItem(ff, true));
                    }
                    else selectedFuncs.Add(tmp.NewItem(ff, false));
                }

            }
            else
            {
                foreach (var ff in ViewBag.Bu)
                {

                    selectedFuncs.Add(tmp.NewItem(ff, true));


                }
            }
            return View(selectedFuncs);
        }
       
        
        [HttpPost]
        
        public IActionResult Write(List<CartItem> selectedFuncs)
        {
            CartFuncs tmp = GetCart();
            var aa = _allFuncs.getBaseLogFuncs.Where(i => i.typeID == 1);
            foreach (var ff in aa)
            {
  
                tmp.AddtoCart(ff);
            }
            
            foreach (var ff in selectedFuncs.Where(p => p.Checked))
            {
                Console.WriteLine(ff.func.name);
                tmp.AddtoCart(ff.func);
            }
            HttpContext.Session.Set("Cart", tmp);
            tmp.Res();
            return RedirectToActionPermanent("Write","Write");
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
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value != null)
                return JsonSerializer.Deserialize<T>(value);
            else
                return default(T);
        }
    }
}

using ConfLog.Interfaces;
using ConfLog.Models;
using ConfLog.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ConfLog.Controllers
{
    public class CartController : Controller
    {
        private readonly IAllFuncs _funcRep;
        private readonly CartFuncs _cartfunc;
        public CartController(IAllFuncs funcRep, CartFuncs cartfunc)
        {
            _funcRep = funcRep;
            _cartfunc = cartfunc;
        }

        public ViewResult Index()
        {
            //var items = _cartfunc.getCartItems();
            //_cartfunc.listFuncs = items;
            return View(_cartfunc);
        }
        public RedirectToActionResult addToCart(int id)
        {
            var item = _funcRep.Funcs.FirstOrDefault(i => i.id == id);
            if (item !=null )
            {
                _cartfunc.AddtoCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}

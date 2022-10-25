using ConfLog.Interfaces;
using ConfLog.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConfLog.Controllers
{
    public class TextController : Controller
    {
        private readonly AppDBContent _appDBcontent;
        private readonly IAllFuncs _allFuncs;
        private readonly IFuncType _funcTypes;
        private readonly IAllOrders _allOrders;

        public TextController(IAllFuncs allFuncs, IFuncType funcTypes, IAllOrders allOrders, AppDBContent appDBcontent)
        {
            _appDBcontent = appDBcontent;
            _allFuncs = allFuncs;
            _funcTypes = funcTypes;
            _allOrders = allOrders;
        }
        string name = "Logging.dll";
        public IActionResult Text()
        {
            CartFuncs tmp = GetCart();
            ConstructorDetails cons = GetCons();
            List < Function > Fres= new List<Function>();
           tmp.listFuncs.ForEach(p => Fres.Add(_allFuncs.getObjectFunc(p.id)));
            List<Constructor> Cres = new List<Constructor>();
            Cres.Add(_appDBcontent.Constructors.First());
            Order Ores =new Order { constructors = Cres, functions=Fres };
            _allOrders.createOrder(Ores,cons);            
           
           
            System.IO.File.WriteAllText("wwwroot//download//Logging//Class1.cs",_appDBcontent.Orders.OrderBy(p=>p.id).Last().result);
            Cmd.CdLibrary();
            return View();
        }
        public IActionResult Instruct()
        {
            CartFuncs tmp = GetCart();
            List<Function> Fres = new List<Function>();
            tmp.listFuncs.ForEach(p => Fres.Add(_allFuncs.getObjectFunc(p.id)));
            return View(Fres);
        }

            public FileResult File()
        {

            FileStream fs = new FileStream("wwwroot//download//Logging//bin//Debug//net6.0//" + name, FileMode.Open);
            //byte[] fileContent = System.IO.File.ReadAllBytes("wwwroot//download//Logging//bin//Debug//net6.0//" + name);
            
            return File(fs, "application/dll", "Logging.dll");
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
    }
}

using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace ConfLog.Models
{
    public class CartFuncs
    {
   
        public CartFuncs()
        {
            listFuncs = new();
            Console.WriteLine("я");
        }
        public string CartId { get; set; }
        public List<Function> listFuncs { get; set; }
       
        public CartItem NewItem(Function func, bool Checked = false)
        {
            return new CartItem
            {
                CartId = CartId,
                func = func,
                Checked = Checked

            };
        }
        public void AddtoCart(Function func)
        {
            listFuncs.Add(func);

        }
        public void Res()
        {
            foreach (var item in listFuncs)
            {
                Console.WriteLine(item.code);
            }
}
        //public List<CartItem> getCartItems()
        //{
        //    return appDBcontent.CartItems.Where(c => c.CartId == CartId).Include(s => s.func).ToList();
        //}

    }
   
}

using ConfLog.Interfaces;
using ConfLog.Models;

namespace ConfLog.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        public OrderRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public void createOrder(Order order, ConstructorDetails tmp)
        {
            order.result =  string.Join(' ', order.constructors.Select(p => p.link).ToArray());
            order.result += string.Join(' ', order.functions.Select(p => string.Join(' ', p.usings.Select(x => x.code).ToArray())).ToArray().Distinct());
            order.result += @"
namespace Logging
{
    public class Logger
    {";
            order.result += string.Join(' ', order.constructors.Select(p => p.field).ToArray());
            order.result += string.Join(' ', order.functions.Select(p => string.Join(' ', p.fields.Select(x => x.code).ToArray())).ToArray().Distinct());
            string change = string.Join(' ', order.constructors.Select(p => p.code).ToArray());
            if (String.IsNullOrEmpty(tmp.Excel) & !order.functions.Where(p=>p.name=="Excel").Any())
            {
                int n = 0;
                while (n != -1)
                {
                    n = change.IndexOf(@"/*Excel*/");
                    int n1 = change.IndexOf(@"/*Excel*/", n + @"/*Excel*/".Length);
                    if (n != -1) change = change.Remove(n, n1 - n + @"/*Excel*/".Length);                    
                }
            }
            if (tmp.Excel != null & order.functions.Where(p => p.name == "Excel").Any())
            {
                int n2 = 0;
                while (true)
                {
                    int n1 = change.IndexOf(@"/*Excel*/", n2 + @"/*Excel*/".Length);
                    n2 = change.IndexOf(@"/*Excel*/", n1 + @"/*Excel*/".Length);
                    int n = change.IndexOf(@" config", n1, n2 - n1);
                    if (n != -1)
                    {
                        change = change.Remove(n, " config".Length);
                        change = change.Insert(n, @""""+ string.Join("//", tmp.Excel.Split('\\')) + @"""");
                        break;
                    }
                }
            }
            if (String.IsNullOrEmpty(tmp.Text) & !order.functions.Where(p => p.name == "Text").Any())
            {
                
                int n = 0;
                while (n != -1)
                {
                    n = change.IndexOf(@"/*Txt*/");
                    int n1 = change.IndexOf(@"/*Txt*/", n + @"/*Txt*/".Length);
                    if (n != -1) change = change.Remove(n, n1 - n + @"/*Txt*/".Length);
                }
            }
            if (tmp.Text != null & order.functions.Where(p => p.name == "Text").Any())
            {
                int n2 = 0;
                while (true)
                {
                    int n1 = change.IndexOf(@"/*Txt*/", n2 + @"/*Txt*/".Length);
                     n2 = change.IndexOf(@"/*Txt*/", n1 + @"/*Txt*/".Length);
                    int n = change.IndexOf(@" config", n1, n2 - n1);
                    if (n != -1)
                    { 

                        change = change.Remove(n, " config".Length);
                        change = change.Insert(n, @""""+string.Join("//",tmp.Text.Split('\\'))+ @"""");
                        break;
                    }
                }
            }
            if (String.IsNullOrEmpty(tmp.Tcp)  & !order.functions.Where(p => p.name == "Tcp").Any())
            {
                int n = 0;
                while (n != -1)
                {
                    n = change.IndexOf(@"/*Tcp*/");
                    int n1 = change.IndexOf(@"/*Tcp*/", n + @"/*Tcp*/".Length);
                    if (n != -1) change = change.Remove(n, n1 - n + @"/*Tcp*/".Length);
                }
            }
            if (tmp.Tcp != null & order.functions.Where(p => p.name == "Tcp").Any())
            {
                int n2 = 0;
                while (true)
                {
                    int n1= change.IndexOf(@"/*Tcp*/",n2 + @"/*Tcp*/".Length);
                     n2 = change.IndexOf(@"/*Tcp*/", n1 + @"/*Tcp*/".Length);
                    int n = change.IndexOf(@" config",n1,n2-n1);
                    if (n!=-1)
                    {
                        change = change.Remove(n, " config".Length);
                        change = change.Insert(n, @""""+tmp.Tcp+ @"""");
                        break;
                    }
                }
            }
            order.result += change;
            change= string.Join(' ', order.functions.Select(p => p.code).ToArray());
            if ( !order.functions.Where(p => p.name == "Excel").Any())
            {
                int n = 0;
                while (n != -1)
                {
                    n = change.IndexOf(@"/*Excel*/");
                    int n1 = change.IndexOf(@"/*Excel*/", n + @"/*Excel*/".Length);
                    if (n != -1) change = change.Remove(n, n1 - n + @"/*Excel*/".Length);
                }
            }
            if (!order.functions.Where(p => p.name == "Text").Any())
            {

                int n = 0;
                while (n != -1)
                {
                    n = change.IndexOf(@"/*Txt*/");
                    int n1 = change.IndexOf(@"/*Txt*/", n + @"/*Txt*/".Length);
                    if (n != -1) change = change.Remove(n, n1 - n + @"/*Txt*/".Length);
                }
            }
            if ( !order.functions.Where(p => p.name == "Database").Any())
            {

                int n = 0;
                while (n != -1)
                {
                    n = change.IndexOf(@"/*Db*/");
                    int n1 = change.IndexOf(@"/*Db*/", n + @"/*Db*/".Length);
                    if (n != -1) change = change.Remove(n, n1 - n + @"/*Db*/".Length);
                }
            }
            if ( !order.functions.Where(p => p.name == "Tcp").Any())
            {
                int n = 0;
                while (n != -1)
                {
                    n = change.IndexOf(@"/*Tcp*/");
                    int n1 = change.IndexOf(@"/*Tcp*/", n + @"/*Tcp*/".Length);
                    if (n != -1) change = change.Remove(n, n1 - n + @"/*Tcp*/".Length);
                }
            }
            order.result += change;
            order.result +=  @"
    }
}";


            appDBContent.Orders.Add(order);
            appDBContent.SaveChanges();

        }
    }
}

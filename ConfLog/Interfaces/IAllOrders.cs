using ConfLog.Models;

namespace ConfLog.Interfaces
{
    public interface IAllOrders
    {
        void createOrder(Order order, ConstructorDetails tmp);
    }
}

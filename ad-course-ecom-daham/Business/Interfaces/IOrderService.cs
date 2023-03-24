using ad_course_ecom_daham.Models;
using ad_course_ecom_daham.Models.Product;

namespace ad_course_ecom_daham.Business.Interfaces
{
    public interface IOrderService
    {
        void AddOrder(Order model);
        List<Order> GetOrders();
        Order GetOrderById(Guid? id);
        void EditOrder(Order model);
        void DeleteOrder(Guid? id);
    }
}

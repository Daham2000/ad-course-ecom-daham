using ad_course_ecom_daham.Models;
using ad_course_ecom_daham.Models.Product;

namespace ad_course_ecom_daham.Business.Interfaces
{
    public interface IOrderService
    {
        public void AddOrder(Order model);
        public List<Order> GetOrders();
        public Order GetOrderById(Guid? id);
        public void EditOrder(Order model);
        public void DeleteOrder(Guid? id);
    }
}

using ad_course_ecom_daham.Models;

namespace ad_course_ecom_daham.Business.Interfaces
{
    public interface IOrderItemService
    {
        public void AddOrderItem(OrderItem model);
        public List<OrderItem> GetOrderItems();
        public List<OrderItem> GetOrderItemById(Guid? id);
        public void EditOrderItem(OrderItem model);
        public void DeleteOrderItem(Guid? id);
    }
}

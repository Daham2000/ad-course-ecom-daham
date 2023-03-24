using ad_course_ecom_daham.Models;

namespace ad_course_ecom_daham.Business.Interfaces
{
    public interface IOrderItemService
    {
        void AddOrderItem(OrderItem model);
        List<OrderItem> GetOrderItems();
        List<OrderItem> GetOrderItemById(Guid? id);
        void EditOrderItem(OrderItem model);
        void DeleteOrderItem(Guid? id);
    }
}

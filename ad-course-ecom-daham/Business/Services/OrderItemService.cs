using ad_course_ecom_daham.Business.Interfaces;
using ad_course_ecom_daham.Data;
using ad_course_ecom_daham.Models;

namespace ad_course_ecom_daham.Business.Services
{
    public class OrderItemService : IOrderItemService
    {
        ApplicationDbContext _context;

        public OrderItemService(ApplicationDbContext context)
        {
            _context = context;
        }
        void IOrderItemService.AddOrderItem(OrderItem model)
        {
            model.oId = Guid.NewGuid();
            _context.Add(model);
            _context.SaveChanges();
        }

        void IOrderItemService.DeleteOrderItem(Guid? id)
        {
            throw new NotImplementedException();
        }

        void IOrderItemService.EditOrderItem(OrderItem model)
        {
            _context.SaveChanges();
        }

        List<OrderItem> IOrderItemService.GetOrderItemById(Guid? id)
        {
            return _context.orderItems.Where((o) => o.oId == id).ToList();
        }

        List<OrderItem> IOrderItemService.GetOrderItems()
        {
            return _context.orderItems.ToList();
        }
    }
}

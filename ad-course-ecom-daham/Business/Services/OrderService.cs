using ad_course_ecom_daham.Business.Interfaces;
using ad_course_ecom_daham.Data;
using ad_course_ecom_daham.Models;

namespace ad_course_ecom_daham.Business.Services
{
    public class OrderService : IOrderService
    {
        ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        void IOrderService.AddOrder(Order model)
        {
            model.oId = Guid.NewGuid();
            _context.Add(model);
            _context.SaveChanges();
        }

        void IOrderService.DeleteOrder(Guid? id)
        {
            throw new NotImplementedException();
        }

        void IOrderService.EditOrder(Order model)
        {
            _context.SaveChanges();
        }

        List<Order> IOrderService.GetOrders()
        {
            return _context.orders.ToList();
        }

        Order IOrderService.GetOrderById(Guid? id)
        {
            return _context.orders.Where((o) => o.oId == id).FirstOrDefault();
        }
    }
}

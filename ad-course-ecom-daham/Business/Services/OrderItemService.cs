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
        /* 
            Adds a new order item to the database using the provided OrderItem object.
            Generates a new Guid for the order item before adding it to the database.
            Model The OrderItem object containing the details of the order item to be added. 
        */
        public void AddOrderItem(OrderItem model)
        {
            model.oId = Guid.NewGuid();
            _context.Add(model);
            _context.SaveChanges();
        }

        /* 
            Deletes an order item with the specified id from the database. Not implemented.
            id The id of the order item to be deleted.
        */
        public void DeleteOrderItem(Guid? id)
        {
            throw new NotImplementedException();
        }

        /* 
            Edit Order Item using OrderItem model object. model represant the data to be edited in the database. 
        */
        public void EditOrderItem(OrderItem model)
        {
            _context.SaveChanges();
        }

        public List<OrderItem> GetOrderItemById(Guid? id)
        {
            return _context.orderItems.Where((o) => o.oId == id).ToList();
        }

        public List<OrderItem> GetOrderItems()
        {
            return _context.orderItems.ToList();
        }
    }
}

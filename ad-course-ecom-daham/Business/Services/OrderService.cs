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

        /* 
            Add a new order using Order object. model Order contain the data to be added to the database. 
        */
        public void AddOrder(Order model)
        {
            model.oId = Guid.NewGuid();
            _context.Add(model);
            _context.SaveChanges();
        }
        /* 
            Delete an order using Order model unique primary key. Guid means unique id defined by c#. 
            This function not yet implemented. 
        */
        public void DeleteOrder(Guid? id)
        {
            throw new NotImplementedException();
        }

        /*
            Edit order by using Order model which contain the data to be updated in the database. 
        */
        public void EditOrder(Order model)
        {
            _context.SaveChanges();
        }

        /*
            Get all orders as a list object. 
        */
        public List<Order> GetOrders()
        {
            return _context.orders.ToList();
        }

        /* 
            Return a single order filtered by Order id. 
        */
        public Order GetOrderById(Guid? id)
        {
            return _context.orders.Where((o) => o.oId == id).FirstOrDefault();
        }
    }
}

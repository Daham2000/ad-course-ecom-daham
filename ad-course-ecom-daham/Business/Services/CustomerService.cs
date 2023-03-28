using ad_course_ecom_daham.Business.Interfaces;
using ad_course_ecom_daham.Data;
using ad_course_ecom_daham.Models.CustomerModels;
using Microsoft.EntityFrameworkCore;

namespace ad_course_ecom_daham.Business.Services
{
    public class CustomerService : ICustomerService
    {
        ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }
        /*
            Add a new customer to the database using this function. Model Customer is represant the all the data
            to be added to the customer table. 
        */ 
        public void AddCustomer(Customer model)
        {
            throw new NotImplementedException();
        }

        /*
            Delete customer using customer primary key id. 
        */
        public void DeleteCustomer(Guid? id)
        {
            throw new NotImplementedException();
        }

        /*
            Edit a customer to the database using this function. Model Customer is represant the all the data
            to be edited of this customer object. 
        */
        public void EditCustomer(Customer model)
        {
            throw new NotImplementedException();
        }

        /*
            Get a single customer using customer primary key. 
        */
        public Customer GetCustomerById(Guid? id)
        {
            return _context.Customer.Where((c) => c.cId == id).FirstOrDefault();
        }

        /*
            Return all customers as a List. Customer is the model used for the List. 
        */
        public List<Customer> GetCustomers()
        {
            return _context.Customer.ToList();
        }
    }
}

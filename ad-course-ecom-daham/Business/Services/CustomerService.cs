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
        void ICustomerService.AddCustomer(Customer model)
        {
            throw new NotImplementedException();
        }

        void ICustomerService.DeleteCustomer(Guid? id)
        {
            throw new NotImplementedException();
        }

        void ICustomerService.EditCustomer(Customer model)
        {
            throw new NotImplementedException();
        }

        Customer ICustomerService.GetCustomerById(Guid? id)
        {
            return _context.Customer.Where((c) => c.cId == id).FirstOrDefault();
        }

        List<Customer> ICustomerService.GetCustomers()
        {
            return _context.Customer.ToList();

        }
    }
}

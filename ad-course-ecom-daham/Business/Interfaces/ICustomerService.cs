using ad_course_ecom_daham.Models.CustomerModels;
using ad_course_ecom_daham.Models.Product;

namespace ad_course_ecom_daham.Business.Interfaces
{
    public interface ICustomerService
    {
        public void AddCustomer(Customer model);
        public List<Customer> GetCustomers();
        public Customer GetCustomerById(Guid? id);
        public Customer GetCustomerByName(string? cEmail, string cPassword);
        public void EditCustomer(Customer model);
        public void DeleteCustomer(Guid? id);
    }
}

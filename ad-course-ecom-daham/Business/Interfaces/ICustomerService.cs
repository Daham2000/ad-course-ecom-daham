using ad_course_ecom_daham.Models.CustomerModels;
using ad_course_ecom_daham.Models.Product;

namespace ad_course_ecom_daham.Business.Interfaces
{
    public interface ICustomerService
    {
        void AddCustomer(Customer model);
        List<Customer> GetCustomers();
        Customer GetCustomerById(Guid? id);
        void EditCustomer(Customer model);
        void DeleteCustomer(Guid? id);
    }
}

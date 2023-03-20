using ad_course_ecom_daham.Models.Product;

namespace ad_course_ecom_daham.Business.Interfaces
{
    public interface IComputerService
    {
        void AddComputer(Computer model);
        List<Computer> GetComputers();
        Computer GetComputerById(Guid? id);
        void EditComputer(Computer model);
        void DeleteComputer(Guid? id);
    }
}

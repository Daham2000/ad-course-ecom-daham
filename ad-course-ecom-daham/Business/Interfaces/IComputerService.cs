using ad_course_ecom_daham.Models.Product;

namespace ad_course_ecom_daham.Business.Interfaces
{
    public interface IComputerService
    {
        public void AddComputer(Computer model);
        public List<Computer> GetComputers();
        public Computer GetComputerById(Guid? id);
        public void EditComputer(Computer model);
        public void DeleteComputer(Guid? id);
    }
}

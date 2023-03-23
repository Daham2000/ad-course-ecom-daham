using ad_course_ecom_daham.Business.Interfaces;
using ad_course_ecom_daham.Data;
using ad_course_ecom_daham.Models.Product;

namespace ad_course_ecom_daham.Business.Services
{
    public class ComputerService : IComputerService
    {
        ApplicationDbContext _context;
        public ComputerService(ApplicationDbContext context)
        {
            _context = context;
        }

        void IComputerService.AddComputer(Computer model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        void IComputerService.DeleteComputer(Guid? id)
        {
            throw new NotImplementedException();
        }

        void IComputerService.EditComputer(Computer model)
        {
            _context.SaveChanges();
        }

        Computer IComputerService.GetComputerById(Guid? id)
        {
            return _context.computers.Where((c) => c.comId == id).FirstOrDefault();
        }

        List<Computer> IComputerService.GetComputers()
        {
            return _context.computers.ToList();
        }
    }
}

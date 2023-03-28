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
        /*
            Adds a new computer to the database using the provided model object.
            Model The Computer object containing the details of the computer to be added.
        */
        public void AddComputer(Computer model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }
        /* 
            Delete a computer using computer primary key id. 
        */
        public void DeleteComputer(Guid? id)
        {
            throw new NotImplementedException();
        }
        /* 
            Edit a computer using computer model object. 
            Model The Computer object containing the details of the computer to be edited.
        */
        public void EditComputer(Computer model)
        {
            _context.SaveChanges();
        }
        /* 
            Return a computer using computer primary key id. 
        */
        public Computer GetComputerById(Guid? id)
        {
            return _context.computers.Where((c) => c.comId == id).FirstOrDefault();
        }
        /* 
            Return all computers as a list. 
        */
        public List<Computer> GetComputers()
        {
            return _context.computers.ToList();
        }
    }
}

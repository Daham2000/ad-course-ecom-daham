using ad_course_ecom_daham.Models;
using ad_course_ecom_daham.Models.CustomerModels;
using ad_course_ecom_daham.Models.Product;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ad_course_ecom_daham.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Computer> computers { get; set; }
        public DbSet<ComVariation> comVariations { get; set; }
        public DbSet<ComVariationOption> comVariationOptions { get; set; }
        public DbSet<Series> series { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
    }
}
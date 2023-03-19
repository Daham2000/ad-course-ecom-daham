using System.ComponentModel.DataAnnotations;

namespace ad_course_ecom_daham.Models.Product
{
    public class Category
    {
        [Key]
        public Guid cateId { get; set; }

        public string cateName { get; set; }
    }
}

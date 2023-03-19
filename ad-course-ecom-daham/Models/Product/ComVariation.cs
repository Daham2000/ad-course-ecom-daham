using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ad_course_ecom_daham.Models.Product
{
    public class ComVariation
    {
        [Key]
        public Guid comvId { get; set; }
        public string comvName { get; set; }
        [ForeignKey("computer")]
        public Guid comId { get; set; }
        public Computer computer { get; set; }
    }
}

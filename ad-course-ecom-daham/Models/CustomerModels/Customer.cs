using System.ComponentModel.DataAnnotations;

namespace ad_course_ecom_daham.Models.CustomerModels
{
    public class Customer
    {
        [Key]
        public Guid cId { get; set; }
        public string cName { get; set; }
        public string cBillingAddress { get; set; }
        public string cShippingAddress { get; set; }
        public string cNic { get; set; }
        public int cPayCardNum { get; set; }
        public int cPayExpDate { get; set; }
        public int cPayCvs { get; set; }
        public int cNumber { get; set; }
        public string cGender { get; set; }
        public DateTime cBirthDay { get; set; }
        public string cPassword { get; set; }
        public string cEmail { get; set; }
    }
}

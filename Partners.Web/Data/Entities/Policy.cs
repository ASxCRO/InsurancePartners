using System.ComponentModel.DataAnnotations;

namespace Partners.Web.Data.Entities
{
    public class Policy : BaseEntity<int>
    {
        public int PartnerId { get; set; }

        [Required(ErrorMessage = "PolicyNumber is required.")]
        [StringLength(20, MinimumLength = 15, ErrorMessage = "PolicyNumber must be between 15 and 20 characters.")]
        public string PolicyNumber { get; set; }

        [Required(ErrorMessage = "PolicyAmount is required.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Please enter a valid decimal number with up to two decimal places")]
        public decimal PolicyAmount { get; set; }
    }
}
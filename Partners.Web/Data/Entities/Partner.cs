using System;
using System.ComponentModel.DataAnnotations;

namespace Partners.Web.Data.Entities
{
    public class Partner : BaseEntity<int>
    {
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "First Name must be between 2 and 255 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Last Name must be between 2 and 255 characters.")]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [StringLength(255, ErrorMessage = "Address cannot exceed 255 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Partner Number is required.")]
        [StringLength(20, ErrorMessage = "Partner Number must be exactly 20 characters.")]
        public string PartnerNumber { get; set; }

        [RegularExpression(@"^\d{11}$", ErrorMessage = "Croatian PIN must be 11 digits.")]
        public string CroatianPIN { get; set; }

        [Required(ErrorMessage = "Partner Type is required.")]
        [Range(1, 2, ErrorMessage = "Invalid Partner Type.")]
        public int PartnerTypeId { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public string CreateByUser { get; set; }

        [Required(ErrorMessage = "Is Foreign is required.")]
        public bool IsForeign { get; set; }

        [StringLength(20, MinimumLength = 10, ErrorMessage = "External Code must be between 10 and 20 characters.")]
        public string ExternalCode { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [RegularExpression("^[M|F|N]$", ErrorMessage = "Invalid Gender.")]
        public char Gender { get; set; }
    }
}
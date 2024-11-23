using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Reader
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(dataType: DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [DataType(dataType: DataType.Date)]
        [Display(Name = "Membership date until")]
        public DateTime MembershipDate { get; set; }

        [Display(Name = "Number of bought books")]
        public long? NumberOfBoughtBooks { get; set; }

        [Display(Name = "Most recent borrowed book")]
        public int? MostRecentTakenBookId { get; set; }
        [ValidateNever]
        [Display(Name = "Most recent borrowed book")]
        public virtual Book MostRecentTakenBook { get; set; }
    }
}

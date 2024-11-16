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

        [Display(Name = "Number of books borrowed")]
        public long? BooksBorrowed { get; set; }
    }
}

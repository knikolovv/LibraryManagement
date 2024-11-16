using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(dataType: DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [MaxLength(40)]
        public string Nationality { get; set; }

        [Display(Name = "Number of published books")]
        public int? NumberOfBooks { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

    }
}

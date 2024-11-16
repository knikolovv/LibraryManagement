using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(30)]
        public string Genre { get; set; }

        [DataType(dataType: DataType.Date)]
        [Display(Name = "Publication date")]
        public DateTime? PublishDate { get; set; }

        [Required]
        [Display(Name = "Author")]
        public int AuthorId { get; set; }

        [ValidateNever]
        public Author Author { get; set; }

        public double? Price { get; set; }

    }
}

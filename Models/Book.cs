using System.ComponentModel.DataAnnotations;
namespace Bookstore.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(500)]
        public string LongDescription { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string ShortDescription { get; set; }
      
        public string ImageUrl { get; set; }
        [Required]
        public Author Author { get; set; }


        // AuthorId ==> this attribute is used  for "Edit method"
        public int AuthorId { get; set; }

    }
}

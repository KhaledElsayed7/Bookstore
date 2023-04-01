using System.ComponentModel.DataAnnotations; // step: 1
namespace Bookstore.Models
{
    public class Author
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]  
        public string FullName { get; set; }
    }
}

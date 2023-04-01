using System.ComponentModel.DataAnnotations;
namespace Bookstore.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public int Password { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Gender { get; set; }
        //public Customer customer { get; set; }
    }
}

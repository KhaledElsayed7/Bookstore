using Bookstore.Models;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.ViewModel
{
    public class BookAuthorViewModel
    {

        public int BookId { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Title { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(500)]
        public string LongDescription { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string ShortDescription { get; set; }
 
        public int AuthorId { get; set; }
      
        public List<Author> Authors { get; set; }

        public IFormFile File { get; set; }

        public string ImageUrl { get; set; }

    }
}

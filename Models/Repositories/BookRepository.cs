using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Models.Repositories
{
    public class BookRepository : IRepository<Book>
    {

        //step 2:
        private List<Book> books;

        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book()
                {
                 Id =1,
                 Title="C# Programming",
                 LongDescription ="Long Description ...",
                 ShortDescription ="Short Description ...",
                 ImageUrl = "Go.jpg",
                 Author = new Author{Id=1, FullName = "Khalid Assaadani" }
                },
                  new Book()
                {
                 Id =2,
                 Title="Java Programming",
                 LongDescription ="Long Description ...",
                 ShortDescription ="Short Description ...",
                 ImageUrl = "Java.jpg",
                 Author = new Author{Id=1, FullName = "Khalid Assaadani" }
                },
                    new Book()
                {
                 Id =3,
                 Title="python Programming",
                 LongDescription ="Long Description ...",
                 ShortDescription ="Short Description ...",
                 ImageUrl = "javascript.jpg",
                 Author = new Author{Id=1, FullName = "Khalid Assaadani" }
                }

            };
        }
        // step 1:
        public void Add(Book book)
        {
            book.Id = books.Max(item => item.Id) + 1;
            books.Add(book);
        }
        public void Edit(int id, Book editedBook)
        {
            var Book = GetById(id);
            Book.Title = editedBook.Title;
            Book.LongDescription = editedBook.LongDescription;
            Book.ShortDescription = editedBook.ShortDescription;
            Book.Author = editedBook.Author;
            Book.ImageUrl = editedBook.ImageUrl;

        }
        public void Delete(int id)
        {
            var book = GetById(id);
            books.Remove(book);
        }
        public Book GetById(int id)  // very important method
        {
            return books.Single(item => item.Id == id);
        }
        public List<Book> GetAll()  // important method
        {
            return books;
        }

        //public object List()
        //{
        //    throw new System.NotImplementedException();
        //}
    }

}

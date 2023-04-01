using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Models.Repositories.Repo
{
    public class BookDbRepository : IRepository<Book>
    {
        BookstoreDbContext db;
        public BookDbRepository(BookstoreDbContext _db)
        {
            db = _db;
        }
        // step 1:
        public void Add(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }
        public void Edit(int id, Book editedBook)
        {
            var Book = GetById(id);

            Book.Title = editedBook.Title;
            Book.LongDescription = editedBook.LongDescription;
            Book.ShortDescription = editedBook.ShortDescription;
            Book.Author = editedBook.Author;
            Book.ImageUrl = editedBook.ImageUrl;
            db.Books.Update(Book);
            db.SaveChanges();

        }
        public void Delete(int id)
        {
            var book = GetById(id);
            db.Books.Remove(book);
            db.SaveChanges();
        }
        public Book GetById(int id)  // very important method
        {
            var book = db.Books.Single(item => item.Id == id);
            return book;
        }
        public List<Book> GetAll()  // important method
        {
            var books = db.Books.ToList();
            return books;
        }

        //public object List()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}

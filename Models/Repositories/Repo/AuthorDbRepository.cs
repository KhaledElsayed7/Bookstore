using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Models.Repositories.Repo
{
    public class AuthorDbRepository : IRepository<Author>
    {
        BookstoreDbContext db;
        public AuthorDbRepository(BookstoreDbContext _db)
        {
            db = _db;
           
        }
        //step 1:
        public void Add(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
        }
        public void Edit(int id, Author newAuthor)
        {
            var oldAuthor = db.Authors.Single(item => item.Id == id);
            oldAuthor.FullName = newAuthor.FullName;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var author = GetById(id);
            db.Authors.Remove(author);
            db.SaveChanges();
        }
        public List<Author> GetAll()
        {
            var authors = db.Authors.ToList();
            return authors;
        }
        public Author GetById(int id)
        {
            var author = db.Authors.Single(item => item.Id == id);
            return author;
        }

        //public object List()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

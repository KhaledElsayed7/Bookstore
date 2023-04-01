using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Models.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {
        //step 2:
        public List<Author> Authors { get; set; }
        public AuthorRepository()
        {

            Authors = new List<Author>()
            {
                new Author
                {
                    Id=1, FullName="Khalid Assaadani"
                },
                new Author
                {
                    Id=2, FullName="Hameed Mokbil"
                },
                  new Author
                {
                    Id=3, FullName="Ahmed Taha"
                },
            };
        }
        //step 1:
        public void Add(Author author)
        {
            Authors.Add(author);
        }
        public void Edit(int id, Author newAuthor)
        {
            var oldAuthor = GetById(id);
            oldAuthor.FullName = newAuthor.FullName;
        }
        public void Delete(int id)
        {
            var author = GetById(id);
            Authors.Remove(author);
        }
        public List<Author> GetAll()
        {
            return Authors;
        }
        public Author GetById(int id)
        {
            return Authors.Single(item => item.Id == id);
        }

        //public object List()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

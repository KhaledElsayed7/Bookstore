using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Models.Repositories.Repo
{
    public class CustomerDbRepository : IRepository<Customer> 
    {
        BookstoreDbContext db;
        public CustomerDbRepository(BookstoreDbContext _db)
        {
            db = _db;   
        }
        public void Add(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }
        public void Edit(int Id, Customer newCustomer)
        {
            var oldCustomer = GetById(Id);
            oldCustomer.FullName = newCustomer.FullName;
            oldCustomer.Password = newCustomer.Password;
            oldCustomer.Phone = newCustomer.Phone;
            oldCustomer.Country = newCustomer.Country;
            oldCustomer.Gender = newCustomer.Gender;
            db.SaveChanges();
        }
        public void Delete(int Id)
        {
            var customer = GetById(Id);
            db.Customers.Remove(customer);
            db.SaveChanges();
        }
        public Customer GetById(int Id)
        {
            var customer = db.Customers.Single(item => item.Id == Id);
            return customer;
        }
        public List<Customer> GetAll()
        {
            var books = db.Customers.ToList();
            return books;
        }
       
    }
}

using Bookstore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Bookstore
{
    public class CustomerRepository : IRepository<Customer>
    {
        public List<Customer> Customers { get; set; }

        public CustomerRepository()
        {
            Customers = new List<Customer>()
            {
                new Customer()
                {
                    Id = 1,
                    FullName = "Ahmed Ali",
                    Password = 1123456,
                    Phone = 01122224444,
                    Country = "Egypt",
                    Gender = "male",
                },
                new Customer()
                {
                    Id = 2,
                    FullName = "Ahmed Said",
                    Password = 1123456,
                    Phone = 01122227777,
                    Country = "Egypt",
                    Gender = "male",
                },
                new Customer()
                {
                    Id = 3,
                    FullName = "Sami Samir",
                    Password = 1123456,
                    Phone = 01122228888,
                    Country = "Egypt",
                    Gender = "male",
                }

            };
        }
        public void Add(Customer customer)
        {
            Customers.Add(customer);
        }
        public void Edit(int Id, Customer newCustomer)
        {
            var oldCustomer = GetById(Id);
            oldCustomer.FullName = newCustomer.FullName;
            oldCustomer.Password = newCustomer.Password;
            oldCustomer.Phone = newCustomer.Phone;
            oldCustomer.Country = newCustomer.Country;
            oldCustomer.Gender = newCustomer.Gender;
        }
        public void Delete(int Id)
        {
            var customer = GetById(Id);
            Customers.Remove(customer);
        }
        public Customer GetById(int Id)
        {
            var customer = Customers.Single(item => item.Id == Id);
            return customer;
        }
        public List<Customer> GetAll()
        {
            return Customers;
        }
        //public object List()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
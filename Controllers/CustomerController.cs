using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Controllers
{
    public class CustomerController : Controller
    {
        //public ICustomer Customer { get; set; }
        //public CustomerController(ICustomer customer)
        //{
        //    Customer = customer;
        //}
        //public IActionResult Index()
        //{
        //    var customerName = Customer.GetName();
        //    return View("Index",customerName);
        //}
        
         public IRepository<Customer> Repository { get; set; }
        public CustomerController(IRepository<Customer> repository)
        {
            Repository = repository;
        }
        public IActionResult Index()
        {
            var Customers = Repository.GetAll(); 
            return View(Customers);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {

            try
            {
                Repository.Add(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }
        public IActionResult Edit(int Id)
        {
            var customer = Repository.GetById(Id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(int Id, Customer customer)
        {
            try
            { 
            Repository.Edit(Id, customer);
            return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int Id, Customer customer)
        {
            try
            {
                Repository.Delete(Id);
                return RedirectToAction(nameof(Index));
            }
            catch 
            { 
            return View();
            }
        }
        public IActionResult Details()
        {
            return View();
        }


    }
}

using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Bookstore.Controllers
{
    public class AuthorController : Controller
    {
        public IRepository<Author> Repository { get; set;}
        public AuthorController(IRepository<Author> repository)
        {
            Repository = repository;
        }
        public IActionResult Index()
        {
            var authors = Repository.GetAll();
            return View(authors);
        }
        public IActionResult Index_Layout()
        {
            var authors = Repository.GetAll();
            return View(authors);
        }
        public IActionResult Details(int id)
        {
            var author = Repository.GetById(id);
            return View(author);
        }
        public IActionResult Details_Layout(int id)
        {
            var author = Repository.GetById(id);
            return View(author);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Repository.Add(author);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            ModelState.AddModelError("", "Error");
            return View();
            
        }
        public IActionResult Edit(int Id)
        {  
            var author = Repository.GetById(Id);
            return View(author);
        }
        [HttpPost]
        public IActionResult Edit(int id,Author author)
        {
            if(ModelState.IsValid)
            { 
                try
                {
                    Repository.Edit(id, author);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    return View(ex.Message);
                }
            }
            ModelState.AddModelError("","Error");
            return View();
        }
        public IActionResult Delete(int Id)
        {
            var author = Repository.GetById(Id);
            return View(author);
        }
        [HttpPost]
        public IActionResult Delete(int id, Author author)
        {
            if(ModelState.IsValid)
            { 
                try
                {
                    Repository.Delete(id);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    return View(ex.Message);
                }
            }
            ModelState.AddModelError("", "Error");
            return View();
        }
        //[HttpPost]
        //public IActionResult Create(BindAttribute ("Id,FullName") IRepository<Author> author)
        //{
        //    return View();
        //}
    }
}

using Bookstore.Models;
using Bookstore.Models.Repositories;
using Bookstore.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Bookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly IRepository<Book> Repository;
        private readonly IRepository<Author> AuthorRepository;
        private readonly IHostingEnvironment Hosting;

        public BookController(IRepository<Book> repository,
                              IRepository<Author> authorRepository,
                              IHostingEnvironment hosting)
        {
            Repository = repository;
            AuthorRepository = authorRepository;
            Hosting = hosting;
        }
        
        public ActionResult Index()
        {

            var book = Repository.GetAll();
            return View(book);
           
        }
        public ActionResult Index_Layout()
        {

            var book = Repository.GetAll();
            return View(book);

        }
        // Homepage
        public ActionResult HomePage()
        {

            var book = Repository.GetAll();
            return View(book);

        }
        //create method : create with ViewModel
        [HttpGet]
        public ActionResult Create()
        {
            var Model = new BookAuthorViewModel
            {
                Authors = FillSelectList()
            };
            return View(Model);
        }
        [HttpPost]
        public ActionResult Create(BookAuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                try
                {  // Note: this type can upload { image, word, PDF, Video } file
                    string fileName = string.Empty;
                    if(model.File != null)
                    {
                        string uploads = Path.Combine(Hosting.WebRootPath, "uploads");
                        fileName = model.File.FileName;
                        string fullPath = Path.Combine(uploads, fileName);
                        model.File.CopyTo(new FileStream(fullPath, FileMode.Create));   
                    }

                    if (model.AuthorId == -1)  // to select author
                    {
                        ViewBag.Message = " Please select an author from List";
                        return View(GetAllAuthors());
                    }

                    var author = AuthorRepository.GetById(model.AuthorId);
                    Book book = new Book
                    {
                        Id = model.BookId,
                        Title = model.Title,
                        LongDescription = model.LongDescription,
                        ShortDescription = model.ShortDescription,
                        Author = author,
                        ImageUrl = fileName
                  
                    };
                    Repository.Add(book);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                } 
            }
            ModelState.AddModelError("", "Please fill all required fields");
            return View(GetAllAuthors());
        }

        public IActionResult Details(int Id)
        {
            var book = Repository.GetById(Id);
            return View(book);
        }
        public IActionResult Details_Layout(int Id)
        {
            var book = Repository.GetById(Id);
            return View(book);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var book = Repository.GetById(id);
            //var authorId = book.Author == null ? book.Author.Id = 0 : book.Author.Id;
            var authorId = book.AuthorId;
            BookAuthorViewModel viewModel = new BookAuthorViewModel
            {
                BookId = book.Id,
                Title = book.Title,
                LongDescription = book.LongDescription,
                ShortDescription = book.ShortDescription,
                AuthorId = authorId,
                Authors = AuthorRepository.GetAll().ToList(),
                ImageUrl = book.ImageUrl 
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, BookAuthorViewModel viewModel)
        {
            try
            {
                string fileName = string.Empty;
                if (viewModel.File != null)
                {
                    string uploads = Path.Combine(Hosting.WebRootPath, "uploads");
                    fileName = viewModel.File.FileName;
                    string fullPath = Path.Combine(uploads, fileName);

                    // delete the old file
                    string oldFileName = Repository.GetById(viewModel.BookId).ImageUrl;
                    string fullOldPath = Path.Combine(uploads, oldFileName);
                    if(fullPath != fullOldPath)
                    { 
                    System.IO.File.Delete(fullOldPath);
                    //save the new file
                    viewModel.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }
                }
                var author = AuthorRepository.GetById(viewModel.AuthorId);
                Book book = new Book
                {
                   
                    Title = viewModel.Title,
                    LongDescription = viewModel.LongDescription,
                    ShortDescription = viewModel.ShortDescription,
                    Author = author,
                    ImageUrl = fileName
                   
                };
                Repository.Edit(viewModel.BookId, book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
        }
        public IActionResult Delete(int Id)
        {
            var book = Repository.GetById(Id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Delete(int id, Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var thisBook = Repository.GetById(id);
                    Repository.Delete(thisBook.Id);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }
            ModelState.AddModelError("", "Error");
            return View();
        }

        // Used in Create : Post
        List<Author> FillSelectList()
        {
            var authors = AuthorRepository.GetAll().ToList();
            authors.Insert(0, new Author { Id = -1, FullName = "--- Please Select Author From List ---" });
            return authors;
        }

        BookAuthorViewModel GetAllAuthors()
        {
            var vModel = new BookAuthorViewModel
            {
                Authors = FillSelectList()
            };
            return vModel;
        }
    }
}

//    Author = new Author
//    {
//        Id = viewModel.AuthorId,
//        FullName =
//AuthorRepository.GetById(viewModel.AuthorId).FullName
//    }
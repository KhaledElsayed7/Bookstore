using Bookstore.Models;
using Bookstore.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bookstore.ViewComponents
{
    public class AuthorNamesViewComponent : ViewComponent
    {
        private readonly IRepository<Author> _repository;
        public AuthorNamesViewComponent(IRepository<Author> repository)
        {
            _repository = repository;
        }
        public IViewComponentResult Invoke()
        {
            var authorNames = _repository.GetAll()
            .Select(c => c.FullName)
            .ToList();
            return View(authorNames);
        }
    }
}

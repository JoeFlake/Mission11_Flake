using Microsoft.AspNetCore.Mvc;
using Mission11_Flake.Models;
using Mission11_Flake.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_Flake.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repo;
        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }
        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            var listOfBooks = new BooksListViewModel
            {
                Books = _repo.Books
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };

            return View(listOfBooks);
        }
    }
}

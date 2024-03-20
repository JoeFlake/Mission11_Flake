using Microsoft.AspNetCore.Mvc;
using Mission11_Flake.Models;
using Mission11_Flake.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_Flake.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repo;
        // Constructor to inject the book repository dependency
        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        // Action method to handle the index page request
        // It displays a list of books with pagination
        public IActionResult Index(int pageNum)
        {
            int pageSize = 10; // show 10 books per page

            // Retrieve a subset of books based on page number and page size
            var listOfBooks = new BooksListViewModel
            {
                Books = _repo.Books
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                // Provide pagination information to the view
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

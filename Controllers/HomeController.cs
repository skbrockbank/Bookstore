using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models.ViewModels;

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookstoreRepository _repository;

        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBookstoreRepository repository)
        {
            _logger = logger;
            //Set the private repository equal to the repository that was passed in
            _repository = repository;
        }

        //Set the default page number to 1
        public IActionResult Index(string category, int page = 1)
        {
            //Pass the  list of books for that page into the view
            return View(new BookListViewModel
            {
                Books = _repository.Books
                    //Select the items from the right category
                    .Where(b => category == null || b.Category == category)
                    .OrderBy(b => b.BookID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                ,
                //Build the paging info
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    // Change the page numbers based on if a category is selected
                    TotalNumItems = category == null ? _repository.Books.Count() : _repository.Books.Where(x => x.Category == category).Count()
                },
                CurrentCategory = category
            });
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

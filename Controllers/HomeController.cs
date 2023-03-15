using Microsoft.AspNetCore.Mvc;
using MyBookStore.Models;
using MyBookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;
        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int resSize = 5;

            var x = new BooksViewModel
            {
                //sort order of books & split across pages
                Books = repo.Books
                .Where(p => p.Category == bookCategory || bookCategory == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * resSize)
                .Take(resSize),

                PageInfo = new PageInfo
                {
                    // filter based on genre
                    TotBooks = //repo.Books.Count(),
                        (bookCategory == null 
                        ? repo.Books.Count() 
                        : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    BooksPerPage = resSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}

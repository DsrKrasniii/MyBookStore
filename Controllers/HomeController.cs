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
        public IActionResult Index(int pageNum = 1)
        {
            int resSize = 5;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * resSize)
                .Take(resSize),

                PageInfo = new PageInfo
                {
                    TotBooks = repo.Books.Count(),
                    BooksPerPage = resSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Models.ViewModels
{
    public class PageInfo
    {
        public int TotBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        // Page calculation
        public int TotalPages => (int) Math.Ceiling((double) TotBooks / BooksPerPage);
    }
}

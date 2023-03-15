using Microsoft.AspNetCore.Mvc;
using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repo { get; set; }
        private Basket basket { get; set; }

        public PurchaseController (IPurchaseRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Pay());
        }

        [HttpPost]
        public IActionResult Checkout(Pay payment)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your basket is empty");
            }

            if (ModelState.IsValid)
            {
                payment.Lines = basket.Items.ToArray();
                repo.SavePurchase(payment);
                basket.ClearBasket();

                return RedirectToPage("/PostPurchase");
            }
            else
            {
                return View();
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MyBookStore.Models;
namespace SportsStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        //Cart Summary instantiation
        private Basket cart;
        public CartSummaryViewComponent(Basket cartService)
        {
            //cart summary declaration
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
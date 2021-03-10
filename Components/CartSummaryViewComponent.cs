using Microsoft.AspNetCore.Mvc;
using Bookstore.Models;
namespace SportsStore.Components
{
    //Used to add the cart summary at the top of each page
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Infrastructure;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore.Pages
{
    public class CartModel : PageModel
    {
        private IBookstoreRepository repository;

        public CartModel(IBookstoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }

        //If the return url is nul, set it to the root
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        //Convert the cart back from json
        public IActionResult OnPost(long bookID, string returnUrl)
        {
            Book book = repository.Books
                .FirstOrDefault(p => p.BookID == bookID);
            Cart.AddItem(book, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove (long BookID, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                            cl.Book.BookID == BookID).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;

namespace Bookstore.Components
{
    //Inherit from the view component class
    public class NavigationMenuViewComponent : ViewComponent
    {
        // Bring in the repository
        private IBookstoreRepository repository;
        public NavigationMenuViewComponent(IBookstoreRepository r)
        {
            repository = r;
        }

        //Return a view with the books
        public IViewComponentResult Invoke()
        {
            //Set the selected category so we can highlight it
            ViewBag.SelectedType = RouteData?.Values["category"];
            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}

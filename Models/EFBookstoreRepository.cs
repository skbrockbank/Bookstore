using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    //Inherit from IBookstoreRepository
    public class EFBookstoreRepository : IBookstoreRepository
    {
        //Create context object
        private BookstoreDbContext _context;

        //Constructor
        public EFBookstoreRepository (BookstoreDbContext context)
        {
            //Store the parameter context into the private context
            _context = context;
        }

        //Set the books to the list of books
        public IQueryable<Book> Books => _context.Books;
    }
}

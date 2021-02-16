using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    //Create a template to inherit from
    public interface IBookstoreRepository
    {
        //Create a place for information to be queried from
        IQueryable<Book> Books { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalNumItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        //Calculate the total number of pages needed
        public int TotalPages => (int)Math.Ceiling((decimal)TotalNumItems / ItemsPerPage);
    }
}

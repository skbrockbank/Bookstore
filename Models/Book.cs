using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Book
    {
        //Make BookID the key for the class
        [Key]
        public int BookID { get; set; }

        [Required]
        //Verify that the ISBN is in the proper format
        [RegularExpression("^(97(8|9))?\\-\\d{10}$",
            ErrorMessage = "Please enter a valid ISBN number.")]
        public string ISBN { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Classification { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public double Price { get; set; }
    }
}

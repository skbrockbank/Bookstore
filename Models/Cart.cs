using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        //Add item to the cart
        public virtual void AddItem(Book book, int qty)
        {
            //Check if the item is already in the cart
            CartLine line = Lines
                .Where(b => b.Book.BookID == book.BookID)
                .FirstOrDefault();

            //If the item isn't in the cart, add it
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = qty
                });
            }
            //If the item is already in the cart, update the quantity
            else
            {
                line.Quantity += qty;
            }
        }

        //Remove an item from the cart
        public virtual void RemoveLine(Book book) =>
            Lines.RemoveAll(x => x.Book.BookID == book.BookID);

        //Clear the cart
        public virtual void Clear() => Lines.Clear();

        //Calculate total price in cart
        public decimal ComputeTotalSum() => Lines.Sum(e => e.Book.Price * e.Quantity);

        //Class for each object in the cart
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}

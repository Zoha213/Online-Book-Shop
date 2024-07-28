using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApi.DataAcessLayer;
using BookStoreApi.Model;

namespace BookStoreApi.BussinessLayer
{
    public class BooksBL
    {
        private readonly BooksDAL booksDLA = new BooksDAL();

        public List<Books> GetBooks()
        {
            return booksDLA.GetBooks();
        }

        public Books GetBooks(int id)
        {
            return booksDLA.GetBooks(id);
        }

        public void AddBooks(Books book)
        {
            booksDLA.AddBooks(book);
        }

        public void DeleteBook(int id)
        {
            booksDLA.DeleteBooks(id);
        }

        public void UpdateBooks(int id, Books book)
        {
            
            var existingProduct = booksDLA.GetBooks(id);
            if (existingProduct != null)
            {
                book.id = id; // Ensure the ID remains unchanged
                booksDLA.UpdateBooks(book);
            }
        }

        public List<Books> GetBooks(string author)
        {
            return booksDLA.GetBooks(author);
        }
    }
}

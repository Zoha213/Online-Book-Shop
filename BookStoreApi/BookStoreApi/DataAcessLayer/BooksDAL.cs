using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookStoreApi.Model;

namespace BookStoreApi.DataAcessLayer
{
    public class BooksDAL
    {
        private static List<Books> books = new List<Books>
        {
            new Books {
                id = 1,
                title = "Amar Bail",
                author = "Umera Ahmad",
                description = "Story of imbalanced relationships",
                image = "images/khail.jpg"
            },

            new Books {
                id = 2,
                title = "Main Anmol",
                author = "Nimra Ahmed",
                description = "Regrets from earlier times",
                image = "images/anmol.jpg"
            },

            new Books
            {
                id = 3,
                title = "Muat",
                author = "Dr. Khalid Norani",
                description = "Death",
                image = "images/maut.jpg"
            }
        };

        public List<Books> GetBooks()
        {
            return books;
        }

        //get by id
        public Books GetBooks(int id) //not list only one book
        {
            return books.FirstOrDefault(b => b.id == id);
        }

        //get all books of same author
        public List<Books> GetBooks(string author)
        {
            return books.Where(p => p.author == author).ToList();
        }

        //add new book
        public void AddBooks(Books add_b)
        {
            add_b.id = books.Max(b => b.id) + 1;
            books.Add(add_b);
        }

        //update existing book

        public void UpdateBooks(Books update_b)
        {
            var existingProduct = books.FirstOrDefault(p => p.id == update_b.id);

            if (existingProduct != null)
            {
                existingProduct.title = update_b.title;
                existingProduct.description = update_b.description;
                existingProduct.author = update_b.author;
                existingProduct.image = update_b.image;
            }
        }

        public void DeleteBooks(int id)
        {
            var book = books.First(p => p.id == id);
            if (book != null)
            {
                books.Remove(book);
            }
        }
    }
}

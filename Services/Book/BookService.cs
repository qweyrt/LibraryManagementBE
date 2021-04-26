using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Services.Book
{
    public class BookService : IBookService
    {
        private LibraryManagementDbContext _context;
        public BookService(LibraryManagementDbContext context)
        {
            _context = context;
        }
        public bool Create(BooksModel book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.BookID == id);
            try
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }

        }

        public List<BooksModel> GetAll()
        {
            return _context.Books.Include(x => x.RequestDetails).ToList();
        }

        public BooksModel GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public bool Update(BooksModel book)
        {
            try
            {
                var item = _context.Books.FirstOrDefault(x => x.BookID == book.BookID);
                item.BookID = book.BookID;
                item.BookName = book.BookName;
                item.Image = book.Image;
                item.CategoryID = book.CategoryID;
                _context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.MicroKernel;
using LibraryManagement.Models;
namespace LibraryManagement.Services.Book
{
    public interface IBookService : IHandler<BooksModel>
    {

    }
}

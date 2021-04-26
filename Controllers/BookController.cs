using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Services.Book;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _bookservice;
        public BookController(IBookService bookService)
        {
            _bookservice = bookService;
        }
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<BooksModel>> Get()
        {
            return _bookservice.GetAll();
        }
        [HttpGet("Admin")]
        //[Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<BooksModel>> GetForAdmin()
        {
            return _bookservice.GetAll();
        }

        [HttpGet("{id}")]

        //[Authorize(Roles = "Admin,User")]
        public ActionResult<BooksModel> Get(int id)
        {
            return _bookservice.GetById(id);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public IActionResult Post(BooksModel book)
        {
            if (_bookservice.Create(book))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult Put(int id, BooksModel book)
        {
            id = book.BookID;
            if (_bookservice.Update(book))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        // [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if (_bookservice.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

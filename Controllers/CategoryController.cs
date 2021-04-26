using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Services.Category;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryservice;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryservice = categoryService;
        }
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<CategoryModel>> Get()
        {
            return _categoryservice.GetAll();
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin,User")]
        public ActionResult<CategoryModel> Get(int id)
        {
            return _categoryservice.GetById(id);
        }


        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public IActionResult Post(CategoryModel category)
        {
            if (_categoryservice.Create(category))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        // [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, CategoryModel category)
        {
            id = category.CategoryID;
            if (_categoryservice.Update(category))
            {
                return Ok();
            }
            return BadRequest();

        }

        [HttpDelete("{id}")]
        // [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if (_categoryservice.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

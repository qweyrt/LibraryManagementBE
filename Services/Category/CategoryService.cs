using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagement.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private LibraryManagementDbContext _context;
        public CategoryService(LibraryManagementDbContext context)
        {
            _context = context;
        }
        public bool Create(CategoryModel category)
        {
            try
            {
                _context.Categories.Add(category);
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
            var category = _context.Categories.FirstOrDefault(x => x.CategoryID == id);
            try
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }

        }

        public List<CategoryModel> GetAll()
        {
            return _context.Categories.Include(x => x.Books).ToList();
        }

        public CategoryModel GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public bool Update(CategoryModel category)
        {
            try
            {
                var item = _context.Categories.FirstOrDefault(x => x.CategoryID == category.CategoryID);
                item.CategoryName = category.CategoryName;
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

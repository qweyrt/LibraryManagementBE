using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using LibraryManagement.Models;

namespace LibraryManagement.Services.User
{
    public class UserService : IUserService
    {
        private LibraryManagementDbContext _context;
        public UserService(LibraryManagementDbContext context)
        {
            _context = context;
        }
        public bool Create(UserModel user)
        {
            try
            {
                _context.Users.Add(user);
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
            var user = _context.Users.FirstOrDefault(x => x.UserId == id);
            try
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }

        }

        public List<UserModel> GetAll()
        {
            return _context.Users.Include(x => x.Requests).ToList();
        }

        public UserModel GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public bool Update(UserModel user)
        {
            try
            {
                var item = _context.Users.FirstOrDefault(x => x.UserId == user.UserId);
                item.Username = user.Username;
                item.DoB = user.DoB;
                item.Name = user.Name;
                item.Password = user.Password;
                item.Role = user.Role;
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

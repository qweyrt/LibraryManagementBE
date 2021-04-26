using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using LibraryManagement.Models;
namespace LibraryManagement.Services.RequestDetails
{
    public class RequestDetailsService : IRequestDetailsService
    {
        private LibraryManagementDbContext _context;
        public RequestDetailsService(LibraryManagementDbContext context)
        {
            _context = context;
        }
        public bool Create(RequestDetailsModel bbrd)
        {
            try
            {
                _context.RequestDetails.Add(bbrd);
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
            var bbrd = _context.RequestDetails.FirstOrDefault(x => x.Id == id);
            try
            {
                _context.RequestDetails.Remove(bbrd);
                _context.SaveChanges();
                return true;


            }
            catch
            {
                return false;
            }

        }

        public List<RequestDetailsModel> GetAll()
        {
            return _context.RequestDetails.ToList();
        }

        public RequestDetailsModel GetById(int id)
        {
            return _context.RequestDetails.Find(id);
        }
        public bool Update(RequestDetailsModel brrd)
        {
            try
            {
                var item = _context.RequestDetails.FirstOrDefault(x => x.Id == brrd.Id);
                item.BookID = brrd.BookID;
                item.RequestID = brrd.RequestID;
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

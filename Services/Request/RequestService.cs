using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Services.Request
{
    public class RequestService : IRequestService
    {
        private LibraryManagementDbContext _context;
        public RequestService(LibraryManagementDbContext context)
        {
            _context = context;
        }

        public bool Create(RequestModel entity)
        {
            throw new NotImplementedException();
        }

        public bool CreateRequest(int userId, List<int> bookIds)
        {
            try
            {
                var checkMonth = _context.Requests.Count(x => x.RequestUserId == userId
                                                                         && x.RequestDate.Month == DateTime.Now.Month
                                                                         && x.RequestDate.Year == DateTime.Now.Year);

                if (bookIds.Count() > 5 || checkMonth > 2)
                {
                    return false;
                }
                else
                {
                    var request = new RequestModel
                    {
                        RequestUserId = userId,
                        RequestDate = DateTime.Now,
                        RequestStatus = Status.Waiting
                    };
                    _context.Requests.Add(request);
                    _context.SaveChanges();

                    foreach (var item in bookIds)
                    {
                        var requestdetail = new RequestDetailsModel
                        {
                            RequestID = request.RequestID,
                            BookID = item
                        };
                        _context.RequestDetails.Add(requestdetail);
                    }
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var bbr = _context.Requests.FirstOrDefault(x => x.RequestID == id);
            try
            {
                _context.Requests.Remove(bbr);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public List<RequestModel> GetAll()
        {

            return _context.Requests.Include(x => x.RequestDetails).ToList();
        }

        public RequestModel GetById(int id)
        {
            return _context.Requests.Find(id);
        }
        public bool Update(RequestModel bbr)
        {
            try
            {
                var item = _context.Requests.Find(bbr.RequestID);
                item.RequestDate = bbr.RequestDate;
                item.RequestStatus = bbr.RequestStatus;
                item.RequestUserId = bbr.RequestUserId;
                item.UpdateRequestDate = bbr.UpdateRequestDate;
                item.RejectUserId = bbr.RejectUserId;
                item.ApprovalUserId = bbr.ApprovalUserId;
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

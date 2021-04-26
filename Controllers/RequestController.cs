using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LibraryManagement.Models;
using LibraryManagement.Services.Request;
using LibraryManagement.Services.RequestDetails;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookBorrowingRequestController : ControllerBase
    {
        private IRequestService _brr;
        private IRequestDetailsService _brrd;
        public BookBorrowingRequestController(IRequestService brr, IRequestDetailsService brrd)
        {
            _brr = brr;
            _brrd = brrd;

        }
        [HttpGet]
        //[Authorize(Roles = "Admin,User")]
        public ActionResult<IEnumerable<RequestModel>> Get()
        {
            return _brr.GetAll();
        }

        [HttpGet("Admin")]
        //[Authorize(Roles = "Admin,User")]
        public ActionResult<IEnumerable<RequestModel>> GetForAdmin()
        {
            return _brr.GetAll();
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin,User")]
        public ActionResult<RequestModel> Get(int id)
        {
            return _brr.GetById(id);
        }


        [HttpPost("{userId}")]
        //[Authorize(Roles = "Admin,User")]
        public IActionResult Post(int userId, List<int> bookIds)
        {
            if (_brr.CreateRequest(userId, bookIds))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, RequestModel brr)
        {
            id = brr.RequestID;
            if (_brr.Update(brr))
            {
                return Ok();
            }
            return BadRequest();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{userId}/approve/{id}")]
        public IActionResult ApproveBorrowRequest(int id, int userId)
        {
            var entity = _brr.GetById(id);

            if (entity != null)
            {
                entity.RequestStatus = Status.Approve;
                entity.ApprovalUserId = userId;
                _brr.Update(entity);
                return Ok(entity);
            }
            return NoContent();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{userId}/reject/{id}/")]
        public IActionResult RejectBorrowRequest(int id, int userId)
        {
            var entity = _brr.GetById(id);

            if (entity != null)
            {
                entity.RequestStatus = Status.Rejected;
                entity.RejectUserId = userId;
                _brr.Update(entity);
                return Ok(entity);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        // [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if (_brr.Delete(id))
            {
                return Ok();
            }
            return BadRequest();

        }
    }
}

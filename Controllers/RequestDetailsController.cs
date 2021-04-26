using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LibraryManagement.Models;
using LibraryManagement.Services.RequestDetails;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BBRDController : ControllerBase
    {
        private IRequestDetailsService _brrd;
        public BBRDController(IRequestDetailsService brrd)
        {
            _brrd = brrd;
        }
        [HttpGet]
        //[Authorize(Roles = "Admin,User")]
        public ActionResult<IEnumerable<RequestDetailsModel>> Get()
        {
            return _brrd.GetAll();
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin,User")]
        public ActionResult<RequestDetailsModel> Get(int id)
        {
            return _brrd.GetById(id);
        }


        [HttpPost]
        //[Authorize(Roles = "Admin,User")]
        public void Post(RequestDetailsModel brrd)
        {
            _brrd.Create(brrd);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        public void Put(int id, RequestDetailsModel brrd)
        {
            _brrd.Update(brrd);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            _brrd.Delete(id);
        }
    }
}

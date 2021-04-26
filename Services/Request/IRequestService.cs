using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;

namespace LibraryManagement.Services.Request
{
    public interface IRequestService : IHandler<RequestModel>
    {
        bool CreateRequest(int userId, List<int> bookIds);

    }
}

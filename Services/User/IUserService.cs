using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;

namespace LibraryManagement.Services.User
{
    public interface IUserService :IHandler<UserModel>
    {
    }
}

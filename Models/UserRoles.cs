using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public enum UserRoles
    {
        [Display(Name = "Admin")]
        Admin,
        [Display(Name = "User")]
        User
    }
}

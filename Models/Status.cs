using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public enum Status
    {
        [Display(Name = "Waiting")]
        Waiting,
        [Display(Name = "Approve")]
        Approve,
        [Display(Name = "Rejected")]
        Rejected
    }
}

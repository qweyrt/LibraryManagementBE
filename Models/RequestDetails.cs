using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class RequestDetailsModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BookID { get; set; }

        public virtual BooksModel Books { get; set; }
        [Required]
        public int RequestID { get; set; }
        public virtual RequestModel Requests { get; set; }
        
    }
}
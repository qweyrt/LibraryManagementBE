using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class BooksModel 
    {
        [Key]
        [Required]
        public int BookID { get; set; }
        [Required]
        public string BookName { get; set; }
        public string Image { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public virtual CategoryModel Category { get; set; }
        public virtual ICollection<RequestDetailsModel> RequestDetails { get; set; }

    }
}
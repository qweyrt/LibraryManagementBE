using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
namespace LibraryManagement.Models
{
    public class RequestModel
    {
        [Key]
        [Required]
        public int RequestID { get; set; }
        [Required]
        public Status RequestStatus { get; set; }
        [Required]
        public string RequestName { get; set; }
        [Required]
        public int RequestUserId { get; set; }
        public virtual UserModel RequestUser { get; set; }
        public int? ApprovalUserId { get; set; }
        [NotMapped]
        public virtual UserModel ApprovalUser { get; set; }

        public int? RejectUserId { get; set; }
        [NotMapped]
        public virtual UserModel RejectUser { get; set; }
        
        [Required]
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public DateTime? UpdateRequestDate { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<RequestDetailsModel> RequestDetails { get; set; }

    }
}
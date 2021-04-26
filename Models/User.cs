using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace LibraryManagement.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime DoB { get; set; }
        [Required]
        public UserRoles Role { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<RequestModel> Requests { get; set; }
    }
}

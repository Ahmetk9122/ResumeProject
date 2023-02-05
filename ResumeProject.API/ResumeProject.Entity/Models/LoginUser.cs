using System;
using System.Collections.Generic;

#nullable disable

namespace ResumeProject.Entity.Models
{
    public partial class LoginUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace ResumeProject.Entity.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string LinkedInUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string GithubUrl { get; set; }
        public string Website { get; set; }
        public string Preference { get; set; }
    }
}

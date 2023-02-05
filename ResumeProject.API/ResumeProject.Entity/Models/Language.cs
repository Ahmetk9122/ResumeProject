using ResumeProject.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace ResumeProject.Entity.Models
{
    public partial class Language : EntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Degree { get; set; }
    }
}

using ResumeProject.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace ResumeProject.Entity.Models
{
    public partial class Education : EntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string School { get; set; }
        public double? DiplomaScore { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Location { get; set; }
    }
}

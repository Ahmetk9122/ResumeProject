using ResumeProject.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace ResumeProject.Entity.Models
{
    public partial class Technology : EntityBase
    {
        public Technology()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}

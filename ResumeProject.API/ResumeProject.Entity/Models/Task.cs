using ResumeProject.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace ResumeProject.Entity.Models
{
    public partial class Task : EntityBase
    {
        public Task()
        {
            WorkExperiences = new HashSet<WorkExperience>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
    }
}

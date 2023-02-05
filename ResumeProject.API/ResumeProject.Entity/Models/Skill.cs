using System;
using System.Collections.Generic;

#nullable disable

namespace ResumeProject.Entity.Models
{
    public partial class Skill
    {
        public Skill()
        {
            Certificates = new HashSet<Certificate>();
            Projects = new HashSet<Project>();
            WorkExperiences = new HashSet<WorkExperience>();
        }

        public int Id { get; set; }
        public string SkillName { get; set; }

        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
    }
}

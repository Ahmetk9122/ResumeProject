using ResumeProject.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace ResumeProject.Entity.Models
{
    public partial class Project : EntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Link { get; set; }
        public string RepoUrl { get; set; }
        public int SkillId { get; set; }
        public int TechnologyId { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual Technology Technology { get; set; }
    }
}

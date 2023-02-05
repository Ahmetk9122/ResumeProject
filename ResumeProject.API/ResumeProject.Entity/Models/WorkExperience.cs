using ResumeProject.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace ResumeProject.Entity.Models
{
    public partial class WorkExperience : EntityBase
    {
        public int Id { get; set; }
        public string Degree { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SkillId { get; set; }
        public int TaskId { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual Task Task { get; set; }
    }
}

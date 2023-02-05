using ResumeProject.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace ResumeProject.Entity.Models
{
    public partial class Certificate :EntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string CertificateUrl { get; set; }
        public int SkillId { get; set; }

        public virtual Skill Skill { get; set; }
    }
}

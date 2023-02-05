using ResumeProject.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProject.Entity.Dto
{
    public class WorkExperienceDto : DtoBase
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
    }
}

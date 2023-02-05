using ResumeProject.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProject.Entity.Dto
{
    public class EducationDto :DtoBase
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

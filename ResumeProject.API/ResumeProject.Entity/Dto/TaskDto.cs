using ResumeProject.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProject.Entity.Dto
{
    public class TaskDto : DtoBase
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}

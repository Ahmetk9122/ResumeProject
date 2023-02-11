using ResumeProject.Entity.Dto;
using ResumeProject.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResumeProject.Interface
{
    public interface ITaskService : IGenericService<Task, TaskDto>
    {
    }
}

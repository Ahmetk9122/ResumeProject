using ResumeProject.Entity.Dto;
using ResumeProject.Entity.Models;
using ResumeProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResumeProject.Bll
{
    public class TaskManager : GenericManager<Task, TaskDto>, ITaskService
    {
        public TaskManager(IServiceProvider service) : base(service)
        {
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using ResumeProject.Dal.Abstract;
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
        public readonly ITaskRepository taskRepository;

        public TaskManager(IServiceProvider service) : base(service)
        {
            taskRepository = service.GetService<ITaskRepository>();

        }
    }
}

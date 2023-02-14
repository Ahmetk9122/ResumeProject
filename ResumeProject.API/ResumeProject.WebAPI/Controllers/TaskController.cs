using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeProject.Entity.Dto;
using ResumeProject.Entity.Models;
using ResumeProject.Interface;
using ResumeProject.WebAPI.Base;

namespace ResumeProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ApiBaseController<ITaskService, Task, TaskDto>
    {
        private readonly ITaskService taskService;
        public TaskController(ITaskService taskService) : base(taskService)
        {
            this.taskService = taskService;

        }
    }
}

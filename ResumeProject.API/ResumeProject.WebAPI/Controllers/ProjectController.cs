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
    public class ProjectController : ApiBaseController<IProjectService, Project, ProjectDto>
    {
        private readonly IProjectService projectService;
        public ProjectController(IProjectService projectService) : base(projectService)
        {
            this.projectService = projectService;

        }
    }
}

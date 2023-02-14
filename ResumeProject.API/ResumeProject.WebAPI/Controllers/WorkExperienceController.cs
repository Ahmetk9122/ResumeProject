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
    public class WorkExperienceController : ApiBaseController<IWorkExperienceService, WorkExperience, WorkExperienceDto>
    {
        private readonly IWorkExperienceService workExperienceService;
        public WorkExperienceController(IWorkExperienceService workExperienceService) : base(workExperienceService)
        {
            this.workExperienceService = workExperienceService;

        }
    }
}

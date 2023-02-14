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
    public class SkillController : ApiBaseController<ISkillService, Skill, SkillDto>
    {
        private readonly ISkillService skillService;
        public SkillController(ISkillService skillService) : base(skillService)
        {
            this.skillService = skillService;

        }
    }
}

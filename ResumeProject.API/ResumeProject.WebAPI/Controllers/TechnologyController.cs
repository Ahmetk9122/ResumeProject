using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeProject.Entity.Dto;
using ResumeProject.Entity.Models;
using ResumeProject.Interface;
using ResumeProject.WebAPI.Base;
using System.Threading.Tasks;

namespace ResumeProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ApiBaseController<ITechnologyService, Technology, TechnologyDto>
    {
        private readonly ITechnologyService technologyService;
        public TechnologyController(ITechnologyService technologyService) : base(technologyService)
        {
            this.technologyService = technologyService;

        }
    }
}

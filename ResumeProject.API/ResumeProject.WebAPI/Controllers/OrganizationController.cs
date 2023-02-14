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
    public class OrganizationController : ApiBaseController<IOrganizationService, Organization, OrganizationDto>
    {
        private readonly IOrganizationService organizationService;
        public OrganizationController(IOrganizationService organizationService) : base(organizationService)
        {
            this.organizationService = organizationService;

        }
    }
}

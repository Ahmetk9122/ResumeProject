using Microsoft.Extensions.DependencyInjection;
using ResumeProject.Dal.Abstract;
using ResumeProject.Entity.Dto;
using ResumeProject.Entity.Models;
using ResumeProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProject.Bll
{
    public class OrganizationManager : GenericManager<Organization, OrganizationDto>, IOrganizationService
    {
        public readonly IOrganizationRepository organizationRepository;

        public OrganizationManager(IServiceProvider service) : base(service)
        {
            organizationRepository = service.GetService<IOrganizationRepository>();

        }
    }
}

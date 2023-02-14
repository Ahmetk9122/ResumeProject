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
    public class EducationManager : GenericManager<Education, EducationDto>, IEducationService
    {
        public readonly IEducationRepository educationRepository;

        public EducationManager(IServiceProvider service) : base(service)
        {
            educationRepository = service.GetService<IEducationRepository>();
        }
    }
}

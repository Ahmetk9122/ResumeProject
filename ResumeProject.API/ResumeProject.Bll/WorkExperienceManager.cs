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
    public class WorkExperienceManager : GenericManager<WorkExperience, WorkExperienceDto>, IWorkExperienceService
    {
        public readonly IWorkExperienceRepository workExperienceRepository;

        public WorkExperienceManager(IServiceProvider service) : base(service)
        {
            workExperienceRepository = service.GetService<IWorkExperienceRepository>();

        }
    }
}

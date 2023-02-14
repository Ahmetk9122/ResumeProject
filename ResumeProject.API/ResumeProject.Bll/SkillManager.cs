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
    public class SkillManager : GenericManager<Skill, SkillDto>, ISkillService
    {
        public readonly ISkillRepository skillRepository;

        public SkillManager(IServiceProvider service) : base(service)
        {
            skillRepository = service.GetService<ISkillRepository>();

        }
    }
}

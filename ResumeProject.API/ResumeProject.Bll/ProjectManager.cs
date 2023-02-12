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
    public class ProjectManager : GenericManager<Project, ProjectDto>, IProjectService
    {
        public ProjectManager(IServiceProvider service) : base(service)
        {
        }
    }
}

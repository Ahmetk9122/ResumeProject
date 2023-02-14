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
    public class LanguageManager : GenericManager<Language, LanguageDto>, ILanguageService
    {
        public readonly ILanguageRepository languageRepository;
        public LanguageManager(IServiceProvider service) : base(service)
        {
            languageRepository = service.GetService<ILanguageRepository>();

        }
    }
}

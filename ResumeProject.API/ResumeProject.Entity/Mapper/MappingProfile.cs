using AutoMapper;
using ResumeProject.Entity.Dto;
using ResumeProject.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProject.Entity.Mapper
{
    //Profile dan kalırım alması gerekmektedir bunun içinde AutoMapper nuget package dan eklenmesi gerekmektedir entity katmanına. 11.0.1 version
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {

            //Reverse map sayesinde entityler dtolara dtolar da entitye dönüştürülmesi sağlanmıştır.
            //Kullanılması için ObjectMapper classı bll (businness logic layer) katmanında yapılmalıdır. Çünkü mimariye göre mapping işlemleri bll katmanını görevidir.
            CreateMap<Certificate , CertificateDto>().ReverseMap();
            CreateMap<Education, EducationDto>().ReverseMap();
            CreateMap<Language, LanguageDto>().ReverseMap();
            CreateMap<LoginUser, LoginUserDto>().ReverseMap();
            CreateMap<Organization, OrganizationDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<Models.Task, TaskDto>().ReverseMap();
            CreateMap<Technology, TechnologyDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<WorkExperience, WorkExperienceDto>().ReverseMap();
            CreateMap<LoginDto, LoginUserDto>();
            CreateMap<LoginUserDto, LoginDto>();




        }
    }
}

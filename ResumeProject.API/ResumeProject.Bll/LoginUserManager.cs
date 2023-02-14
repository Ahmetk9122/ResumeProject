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
    public class LoginUserManager : GenericManager<LoginUser, LoginUserDto>, ILoginUserService
    {
        public readonly ILoginUserRepository loginUserRepository;

        public LoginUserManager(IServiceProvider service) : base(service)
        {
            loginUserRepository = service.GetService<ILoginUserRepository>();

        }
    }
}

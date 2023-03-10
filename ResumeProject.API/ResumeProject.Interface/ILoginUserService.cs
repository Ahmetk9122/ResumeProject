using ResumeProject.Entity.Dto;
using ResumeProject.Entity.IBase;
using ResumeProject.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProject.Interface
{
    public interface ILoginUserService : IGenericService<LoginUser, LoginUserDto>
    {
        IResponse<UserTokenDto> Login(LoginUserDto login);
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResumeProject.Dal.Abstract;
using ResumeProject.Entity.Base;
using ResumeProject.Entity.Dto;
using ResumeProject.Entity.IBase;
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
        private IConfiguration configuration;

        public LoginUserManager(IServiceProvider service, IConfiguration configuration) : base(service)
        {
            loginUserRepository = service.GetService<ILoginUserRepository>();
            this.configuration = configuration;

        }

        public IResponse<UserTokenDto> Login(LoginUserDto login)
        {
            var user = loginUserRepository.Login(ObjectMapper.Mapper.Map<LoginUser>(login));

            if(user != null)
            {
                var dtoUser= ObjectMapper.Mapper.Map<LoginUserDto>(user);
                var token = new TokenManager(configuration).CreateAccessToken(dtoUser);
                var userToken = new UserTokenDto()
                {
                    loginUserDto = dtoUser,
                    AccessToken = token
                };
                return new Response<UserTokenDto>
                {
                    Message = "Token Üretildi.",
                    StatusCode = StatusCodes.Status200OK,
                    Data = userToken
                };
            }
            else
            {
                return new Response<UserTokenDto>
                {
                    Message = "Kullanıcı kodu veya parolanız yanlış",
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Data = null,
                };
            }
        }
    }
}

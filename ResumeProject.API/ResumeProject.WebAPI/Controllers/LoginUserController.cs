using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeProject.Entity.Base;
using ResumeProject.Entity.Dto;
using ResumeProject.Entity.IBase;
using ResumeProject.Entity.Models;
using ResumeProject.Interface;
using ResumeProject.WebAPI.Base;
using System;

namespace ResumeProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginUserController :ControllerBase
    {
        private readonly ILoginUserService loginUserService;
        public LoginUserController(ILoginUserService loginUserService) 
        {
            this.loginUserService = loginUserService;

        }
        [HttpPost("Login")]
        public IResponse<UserTokenDto> Login(LoginUserDto login)
        {
            try
            {
                return loginUserService.Login(login);
            }
            catch(Exception ex )
            {
                return new Response<UserTokenDto>
                {
                    Message = "Error:" + ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null,
                };
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeProject.Entity.Dto;
using ResumeProject.Entity.Models;
using ResumeProject.Interface;
using ResumeProject.WebAPI.Base;

namespace ResumeProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginUserController : ApiBaseController<ILoginUserService, LoginUser, LoginUserDto>
    {
        private readonly ILoginUserService loginUserService;
        public LoginUserController(ILoginUserService loginUserService) : base(loginUserService)
        {
            this.loginUserService = loginUserService;

        }
    }
}

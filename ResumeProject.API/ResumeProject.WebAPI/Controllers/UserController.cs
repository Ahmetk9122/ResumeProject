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
    public class UserController : ApiBaseController<IUserService, User, UserDto>
    {
        private readonly IUserService userService;
        public UserController(IUserService userService) : base(userService)
        {
            this.userService = userService;

        }
    }
}

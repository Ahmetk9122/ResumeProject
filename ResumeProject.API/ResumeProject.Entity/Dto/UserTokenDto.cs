using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProject.Entity.Dto
{
    public class UserTokenDto
    {

        public LoginUserDto loginUserDto { get; set; }
        public object AccessToken { get; set; }
    }
}

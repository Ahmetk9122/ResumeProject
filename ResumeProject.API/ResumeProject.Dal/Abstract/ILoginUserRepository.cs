using ResumeProject.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProject.Dal.Abstract
{
    public interface ILoginUserRepository
    {
        LoginUser Login(LoginUser login);
    }
}

using Microsoft.EntityFrameworkCore;
using ResumeProject.Dal.Abstract;
using ResumeProject.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProject.Dal.Concrete.Entityframework.Repository
{
    public class LoginUserRepository : GenericRepository<LoginUser>, ILoginUserRepository
    {
        public LoginUserRepository(DbContext context) : base(context)
        {
        }

        public LoginUser Login(LoginUser login)
        {
            var loginUser =dbset.Where(x=>x.Email == login.Email && x.Password ==login.Password).FirstOrDefault();
            return loginUser;

        }
    }
}

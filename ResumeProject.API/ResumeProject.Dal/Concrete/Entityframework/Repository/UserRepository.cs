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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}

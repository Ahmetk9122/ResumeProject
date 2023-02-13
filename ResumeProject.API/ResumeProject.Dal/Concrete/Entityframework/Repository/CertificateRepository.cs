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
    public class CertificateRepository : GenericRepository<Certificate>, ICertificateRepository
    {

        //base kalıtım alınan argümana gönderilmek için kullanılır.
      
        public CertificateRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Certificate> GetTotalCertificate()
        {
           return dbset.AsQueryable<Certificate>();
        }
    }
}

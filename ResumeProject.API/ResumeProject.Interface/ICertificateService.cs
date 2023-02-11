using ResumeProject.Entity.Dto;
using ResumeProject.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProject.Interface
{
    public interface ICertificateService :IGenericService<Certificate, CertificateDto>
    {
        //Interface Interfaceden kalıtım alabilir.Kalıtım aldığında üst sınıfın metodlarını implemente etmez.
 
        IQueryable<CertificateDto> GetTotalCertificate();
    }
}

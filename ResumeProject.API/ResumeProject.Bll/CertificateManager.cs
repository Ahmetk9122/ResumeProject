using Microsoft.AspNetCore.Http;
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
    public class CertificateManager : GenericManager<Certificate, CertificateDto>, ICertificateService
    {
        public readonly ICertificateRepository certificateRepository;
        public CertificateManager(IServiceProvider service) : base(service)
        {
        }

        //ICertificateRepository
        public IResponse<IQueryable<CertificateDto>> GetTotalCertificate()
        {
            try
            {
                var list = certificateRepository.GetTotalCertificate();

                var listDto = list.Select(x => ObjectMapper.Mapper.Map<CertificateDto>(x));

                return new Response<IQueryable<CertificateDto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {

                return new Response<IQueryable<CertificateDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
    }
}

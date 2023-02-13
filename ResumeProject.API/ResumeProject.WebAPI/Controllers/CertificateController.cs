using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeProject.Entity.Base;
using ResumeProject.Entity.Dto;
using ResumeProject.Entity.IBase;
using ResumeProject.Entity.Models;
using ResumeProject.Interface;
using ResumeProject.WebAPI.Base;
using System;
using System.Linq;

namespace ResumeProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ApiBaseController<ICertificateService,Certificate,CertificateDto>
    {
        private readonly ICertificateService certificateService;
        public CertificateController(ICertificateService certificateService) :base(certificateService)
        {
            this.certificateService = certificateService;

        }
        [HttpGet("get-total-certificate")]//api/certificate/GetTotalRepost
        public IResponse<IQueryable<CertificateDto>> GetTotalCertificate()
        {
            try
            {
                 return certificateService.GetTotalCertificate();
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

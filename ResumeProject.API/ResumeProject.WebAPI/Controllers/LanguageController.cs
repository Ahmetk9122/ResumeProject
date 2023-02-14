﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeProject.Entity.Dto;
using ResumeProject.Entity.Models;
using ResumeProject.Interface;
using ResumeProject.WebAPI.Base;

namespace ResumeProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ApiBaseController<ILanguageService, Language, LanguageDto>
    {
        private readonly ILanguageService languageService;
        public LanguageController(ILanguageService languageService) : base(languageService)
        {
            this.languageService = languageService;

        }
    }
}

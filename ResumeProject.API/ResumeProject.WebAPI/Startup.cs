using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ResumeProject.Bll;
using ResumeProject.Dal.Abstract;
using ResumeProject.Dal.Concrete.Entityframework.Context;
using ResumeProject.Dal.Concrete.Entityframework.Repository;
using ResumeProject.Dal.Concrete.Entityframework.UnitOfWork;
using ResumeProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeProject.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region JwtTokenService
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => 
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer=true,
                        ValidateAudience=true,
                        ValidIssuer=Configuration["Tokens:Issuer"],
                        ValidAudience=Configuration["Tokens:Issuer"],
                        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                        RequireSignedTokens=true,
                        RequireExpirationTime=true,

                    };
                });
            #endregion

            #region AplicationContext
            services.AddDbContext<ResumeContext>();
            services.AddScoped<DbContext, ResumeContext>();
            #endregion

            #region ServiceSection
            services.AddScoped<ICertificateService, CertificateManager>();
            services.AddScoped<IEducationService, EducationManager>();
            services.AddScoped<ILanguageService, LanguageManager>();
            services.AddScoped<ILoginUserService, LoginUserManager>();
            services.AddScoped<IOrganizationService, OrganizationManager>();
            services.AddScoped<IProjectService, ProjectManager>();
            services.AddScoped<ITaskService, TaskManager>();
            services.AddScoped<ITechnologyService, TechnologyManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IWorkExperienceService, WorkExperienceManager>();
            services.AddScoped<ISkillService, SkillManager>();


            #endregion

            #region RepositorySection
            services.AddScoped<ICertificateRepository, CertificateRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILoginUserRepository, LoginUserRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWorkExperienceRepository, WorkExperienceRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();

            #endregion

            #region UnitOfWork
            services.AddScoped<IUnitOfWork, UnitofWork>();
            #endregion


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ResumeProject.WebAPI", Version = "v1" });
                #region TokenEntryBlock
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    //Token alma özellikleri
                    In = ParameterLocation.Header,
                    Description = "Please insert token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                  {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string [] { }
                  }
                });
                #endregion
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ResumeProject.WebAPI v1"));
            }
            #region Authorization
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BMS.WebApi v1");
            });
            #endregion

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

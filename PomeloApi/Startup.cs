﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using PomeloApi.Extensions;
using PomeloApi.Validation;
using PomeloButter.DependencyInjection;
using PomeloButter.Repository.MySQL;
using PomeloButter.Repository.TypeHelper;


namespace PomeloApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(option =>
                {
                    option.SerializerSettings.ContractResolver=new CamelCasePropertyNamesContractResolver();
                });
            services.AddHttpsRedirection(option =>
                {
                    option.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                    option.HttpsPort = 5001;
                });
            services.AddDbContext<PomeloContext>(options => options.UseMySql(Configuration.GetConnectionString("mysqlConnection")));
            RepositoryInjection.ConfigureRepository(services);
            BusinessInjection.ConfigureBusiness(services);
            services.AddSingleton(Configuration);
            PropertyMappingInjection.MappingInjection(services);

            services.AddSwaggerGen(m =>
            {
                m.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "PomeloButterApi", Version = "v1", Description = "Pomelo接口文档" });             
            });

            services.AddAutoMapper();
                                 
            BaseValidator.ConfigureEntityValidator(services);
            services.AddTransient<ITypeHelperService, TypeHelperService>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper>(options =>
            {
                var actionContext = options.GetService<IActionContextAccessor>().ActionContext;
                return new UrlHelper(actionContext);
            });
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseApiExceptionHandler(loggerFactory);
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pomelo API V1");
                c.RoutePrefix = "";

            });
           // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

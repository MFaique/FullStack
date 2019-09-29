﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStack.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BackEnd.Helpers.Interfaces;
using BackEnd.Helpers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace FullStack
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
            services.AddDbContext<DataContext>(x =>
            x.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(option => 
            option.AddPolicy("AllowAllOrigins", builder => {
                builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials();
            }));

            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<IJWTmanager, JWTmanager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
        IHostingEnvironment env,
        DataContext _db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("AllowAllOrigins");

            // app.UseHttpsRedirection();
            app.UseMvc();

            _db.Database.Migrate();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;
using TestApp.Services;
using TestApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TestApp
{
    public class Startup
    {

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile("appsettings.json")
                            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(Configuration);
            services.AddSingleton<IGreeter, Greeter>();
            services.AddScoped<IDataEntityData,SqlDataEntityData>();

           /* services.AddDbContext<TestAppDbContext>(options => 
                    options.UseSqlServer(Configuration.GetConnectionString("TestApp")));
           */ 
            
            services.AddEntityFramework()
                    .AddSqlServer()
                    .AddDbContext<SqlServerApplicationDbContext>();
            
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<TestAppDbContext>();
            services.AddMultitenancy<AppTenant, AppTenantResolver>();
            services.Configure<MultiTenancyOptions>(Configuration.GetSection("Multitenancy"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            IGreeter greeter)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();
            app.UseIdentity();
            app.UseMultitenancy<AppTenant>();
            app.UseMvc(configureRoutes);
            app.Run(ctx => ctx.Response.WriteAsync("Not Found!"));
        }

        private void configureRoutes(IRouteBuilder routeBuilder)
        {
            // Home/Index
            routeBuilder.MapRoute("Default", 
                "{controller=Home}/{action=Index}/{id?}");
        }
    }
}

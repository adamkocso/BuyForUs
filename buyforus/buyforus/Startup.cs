﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buyforus.Models;
using buyforus.Services;
using buyforus.Services.Helpers.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace buyforus
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                services.AddDbContext<ApplicationContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("ProductionConnection")));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(builder =>
                    builder.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            }

            services.AddTransient<IUserService, UserService>();

            services.BuildServiceProvider().GetService<ApplicationContext>().Database.Migrate();
            services.AddTransient<ICampaignService, CampaignService>();
            services.AddTransient<IProductService, ProductService>();
            services.SetUpAutoMapper();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IBlobService, BlobService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            UserManager<User> userManager)
        {
            SetupRoles.CreateUsersWithRoles(userManager);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
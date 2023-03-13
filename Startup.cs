using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using CodeSec.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CodeSec
{
    public class Startup
    {
    private readonly ILogger _logger;
    public IConfiguration Configuration { get; }
    //startup class that creates services and configures them
    public Startup(IConfiguration config, ILogger<Startup> logger) { //logger used for checklist: 10
      Configuration = config;
      _logger = logger;
    }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
            services.AddTransient<ICodeSecRepository, EFCodeSecRepository>(); 
      services.AddIdentity<IdentityUser, IdentityRole>(options => {
        // Password settings according to checklist 5 & 6
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 12;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.Password.RequiredUniqueChars = 1;
        // Lockout settings according to checklist 5 & 6
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        options.Lockout.MaxFailedAccessAttempts = 2;
        options.Lockout.AllowedForNewUsers = true;
      }).AddEntityFrameworkStores<AppIdentityDbContext>();

            //sets login path to home 
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Home/Login";
                options.AccessDeniedPath = "/Home/AccessDenied";
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //services.AddMvc();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddSession(); //Dotnet core's Session is used for checklist: 8

      //services.AddSingleton<ITodoRepository, TodoRepository>();
      _logger.LogInformation("Added TodoRepository to services");
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession(); //Dotnet core's Session is used for checklist: 8
            app.UseAuthentication(); //Dotnet core's authentication is being used for checklist: 5
            app.UseMvcWithDefaultRoute();
        }
    }
}

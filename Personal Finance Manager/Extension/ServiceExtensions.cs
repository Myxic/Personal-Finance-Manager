using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Personal_Finance_Manager.Data.Interfaces;
using Personal_Finance_Manager.Data.Implementation;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.AspNetCore.Identity;
using Personal_Finance_Manager.Model.Enitities;
using Personal_Finance_Manager.Services.Interface;
using Personal_Finance_Manager.Services.Impentation;
//using IAuthenticationService = Personal_Finance_Manager.Services.Interface.IAuthenticationService;
using Personal_Finance_Manager.Model.DTOs.Requests;
using Personal_Finance_Manager.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Collections.Specialized.BitVector32;
using System.Runtime.Intrinsics.X86;

namespace Personal_Finance_Manager.Extension
{
    public static class ServiceExtensions

    {
        private static readonly IConfiguration _configuration;

        public static void AddDBConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
         ));
          

        }
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("X-Pagination"));
            });

        public static void RegisterServices(this IServiceCollection services)
        {

            // Other service registrations
            // Add the required services for authentication and Identity
            

            // Configure the authentication options
            services.Configure<IdentityOptions>(options =>
            {
                // Set your desired password requirements, lockout settings, etc.
                // For example:
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
            });

            //services.Configure<EmailJSConfiguration>(_configuration.GetSection("EmailJSConfiguration"));



            // Register the IAuthenticationService and AuthenticationService
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            // Register the IEmailService implementation
            services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IBudgetService, BudgetService>();
            services.AddScoped<IGoalService, GoalService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();




        }
    }
    //dotnet ef migrations add AddingEntities --startup-project./Personal\ Finance\ Manager --project./Personal\ Finance\ Manager.Data
    //dotnet ef database update  --startup-project ./Personal\ Finance\ Manager

}


﻿using Microsoft.AspNetCore.Identity;
using Personal_Finance_Manager.Extension;
using Personal_Finance_Manager.Model.Enitities;
using System.Reflection;

namespace Personal_Finance_Manager;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);



        builder.Services.RegisterServices();
        builder.Services.ConfigureCors();

        builder.Services.AddDBConnection(builder.Configuration);

        builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


        //builder.Services.AddAuthorization(cfg =>
        //{
        //    cfg.AddPolicy("Authorization", policy => policy.Requirements.Add(new AuthRequirement()));
        //});

     
       

        builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);

    

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}


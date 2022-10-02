using ApplicationApi.Context;
using ApplicationApi.Contracts;
using ApplicationApi.Repository;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.OpenApi.Models;

namespace sqliteApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Manage Connection to db
            builder.Services.AddSingleton<DapperContext>();
            // Add models to scope
            builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Exercise",
                    Description = "API Query Exercise",

                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
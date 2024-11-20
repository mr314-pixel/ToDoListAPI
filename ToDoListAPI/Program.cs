
using Microsoft.OpenApi.Models;
using System.Reflection;
using ToDoListAPI.Repositories;

namespace ToDoListAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adding an InMemoryDatabase for APIs to simulate data retrieval
            builder.Services.AddScoped<IToDoListRepository, ToDoListRepository>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //Swagger Documentation Section
            var info = new OpenApiInfo()
            {
                Title = "To-Do List API Documentation",
                Version = "v1",
                Description = "A client has commissioned your organisation to build a small application for creating and managing to-do lists. They prefer to use the .NET ecosystem, and have requested that it is used for this solution.",
                Contact = new OpenApiContact()
                {
                    Name = "mr314-pixel",
                    Email = "not@email.com",
                }

            };

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", info);

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

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
}

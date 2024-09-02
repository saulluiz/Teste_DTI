using Estrutura_Base.Interfaces;
using Estrutura_Base.Services;
using Microsoft.AspNetCore.Mvc;

namespace Estrutura_Base
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Configure the FibonacciService as a scoped service to be injected by the dependency injection
            builder.Services.AddScoped<FibonacciService>();
            builder.Services.AddScoped<IImpostoDeRendaService, ImpostoDeRendaService>();

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
}

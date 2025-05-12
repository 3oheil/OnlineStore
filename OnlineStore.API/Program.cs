using OnlineStore.Application.Interfaces;
using OnlineStore.Application.Repositories;
using OnlineStore.Application.Services;
using OnlineStore.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            // EF Core DbContext
            builder.Services.AddDbContext<OnlineStoreDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineStore"),
                sqlOptions => sqlOptions.EnableRetryOnFailure())
            );
            

            // Repository Pattern
            builder.Services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));

            // Application Services
            builder.Services.AddScoped<IOrderService, OrderService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Online Store API V1");
                });

            }

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}

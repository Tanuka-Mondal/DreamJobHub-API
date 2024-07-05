using JobAPI.Context;
using JobAPI.Logging;
using JobAPI.Repository;
using JobAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace JobAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddScoped<IJobService, JobService>();
            builder.Services.AddScoped<IJobRepository, JobRepository>();
            string? connectionStr = builder.Configuration.GetConnectionString("userConnectionString");
            builder.Services.AddDbContext<JobDbContext>(o => o.UseSqlServer(connectionStr));
            builder.Services.AddSingleton<JobLogger>();
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

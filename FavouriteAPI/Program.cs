using FavouriteAPI.Context;
using FavouriteAPI.Logging;
using FavouriteAPI.Repository;
using FavouriteAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace FavouriteAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddScoped<IFavouriteService, FavouriteService>();
            builder.Services.AddScoped<IFavouriteRepository, FavouriteRepository>();
            string? connectionStr = builder.Configuration.GetConnectionString("userConnectionString");
            builder.Services.AddDbContext<FavouriteDbContext>(o => o.UseSqlServer(connectionStr));
            builder.Services.AddSingleton<FavouriteLogger>();
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

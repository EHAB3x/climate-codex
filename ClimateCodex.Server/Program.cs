using Microsoft.EntityFrameworkCore;
using ClimateCodex.Server.Models;
using ClimateCodex.Server.Data;
using ClimateCodex.Server.Repository;

namespace ClimateCodex.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register HttpClient
            builder.Services.AddHttpClient();

            // Add services to the container.
            builder.Services.AddControllersWithViews(); // Enable MVC pattern with views

            // Register your repositories with dependency injection
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IEmissionDataRepo, EmissionDataRepo>();
            builder.Services.AddScoped<IGHGTypeRepo, GHGTypeRepo>();
            builder.Services.AddScoped<IClimateDataRepo, ClimateDataRepo>();
            builder.Services.AddScoped<IRegionRepo, RegionRepo>();

            // Add CORS configuration
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", policy =>
                {
                    policy.WithOrigins("https://localhost:5173") // Add your React app's URL here
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Configure DbContext with SQL Server
            builder.Services.AddDbContext<ClimateCodexDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Swagger Configuration (optional)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Enable CORS in the HTTP request pipeline
            app.UseCors("AllowReactApp");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Define MVC routing
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Handle fallback to React
            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}

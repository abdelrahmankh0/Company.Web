using Company.Data.Contexts;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Repository.Repositories;
using Company.Service.Interfaces;
using Company.Service.Mapping;
using Company.Service.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Company.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<CompanyDbContext>(option => {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

			// builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

			builder.Services.AddScoped<IDepartmentService, DepartmentService>();
			builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddAutoMapper(x => x.AddProfile(new EmployeeProfile()));
			builder.Services.AddAutoMapper(x => x.AddProfile(new DepartmentProfile()));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(config =>
                {
                    config.Password.RequiredUniqueChars = 2;
                    config.Password.RequireDigit = true;
                    config.Password.RequireLowercase = true;
                    config.Password.RequireUppercase = true;
                    config.Password.RequireNonAlphanumeric = true;
                    config.Password.RequiredLength = 8;
                    config.User.RequireUniqueEmail = true;
                    config.Lockout.AllowedForNewUsers = true;
                    config.Lockout.MaxFailedAccessAttempts = 5;
                    config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                }).AddEntityFrameworkStores<CompanyDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(option =>
            {
                option.Cookie.HttpOnly = true;
                option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                option.SlidingExpiration = true;
                option.LoginPath = "/Account/Login";
                option.LogoutPath = "/Account/Logout";
                option.AccessDeniedPath = "/Account/AccessDenied";
                option.Cookie.Name = "Abood";
                option.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                option.Cookie.SameSite = SameSiteMode.Strict;

            }
                );


			var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=SignUp}");

            app.Run();
        }
    }
}

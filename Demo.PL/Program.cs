using Demo.DataAccess.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Demo.PesnL.Services;
using Demo.DataAccess.Repositories.Departments;
using Demo.DataAccess.Repositories.Employees;
using Demo.PesnL.Profiles;
using Demo.PesnL.Services.EmployeeServicess;
using Demo.DataAccess.Repositories.UnitOfWorks;


namespace Demo.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            #region servies (Add services to the container.)
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));    
                options.UseLazyLoadingProxies();
            });


            //builder.Services.AddScoped<IDepartmentRepositories , DepartmentRepositories>();
            builder.Services.AddScoped<IDepartmentServices , DepartmentServices>();
            //builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployyServiec>();
            builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();
            //builder.Services.AddAutoMapper(m => m.AddProfile(new MappingProfiles).Assembly);
            #endregion




            var app = builder.Build();




            #region middelware (Configure the HTTP request pipeline.)
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


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run(); 
            #endregion



        }
    }
}

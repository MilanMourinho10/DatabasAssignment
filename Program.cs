using DB_Assignment.Contexts;
using DB_Assignment.Menus;
using DB_Assignment.Repositories;
using DB_Assignment.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DB_Assignment
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\MilanDataBasTeknikUppgift\DB_Assignment\DB_Assignment\DB_Assignment\Contexts\assignment_db.mdf;Integrated Security=True;Connect Timeout=30"));


            //Repositories
            services.AddScoped<AddressRepository>();
            services.AddScoped<EmployeeRepository>();
            services.AddScoped<PricingUnitRepository>();
            services.AddScoped<PhoneCategoryRepository>();
            services.AddScoped<PhoneRepository>();

            //Services
            services.AddScoped<EmployeeService>();
            services.AddScoped<PhoneService>();


            //Menus
            services.AddScoped<EmployeeMenu>();
            services.AddScoped<PhoneMenu>();
            services.AddScoped<MainMenu>();

            var sp = services.BuildServiceProvider();
            var mainMenu = sp.GetRequiredService<MainMenu>();
            await mainMenu.StartAsync();
        }
    }
}

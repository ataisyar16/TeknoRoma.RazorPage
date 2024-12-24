using Microsoft.EntityFrameworkCore;
using TeknoRoma.BL.BL.Managers.Abstract;
using TeknoRoma.BL.BL.Managers.Concrete;
using TeknoRoma.DAL.DAL.Contexts;

namespace TeknoRoma.Razorpage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddScoped(typeof(IManager<>), typeof(Manager<>));

            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Constr")));

            var app = builder.Build();

            // Veritabaný baðlantýsýný kontrol etme kodu
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();
                try
                {
                    context.Database.EnsureCreated();
                    Console.WriteLine("Veritabaný baðlantýsý baþarýlý!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Veritabaný baðlantý hatasý: {ex.Message}");
                }
            }


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            app.MapRazorPages();

            app.Run();
        }
    }
}

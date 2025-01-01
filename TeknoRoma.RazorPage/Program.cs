using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeknoRoma.DAL.DAL.Contexts;
using TeknoRoma.Entities.Entities.Concrete;
using TeknoRoma.Razorpage.Extensions;

namespace TeknoRoma.Razorpage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Database Create Edilmismi yada bekleyen migration varmi kontrol ediliyor
            using (var db = new AppDbContext())
            {
                if (!db.Database.EnsureCreated())
                {
                    if (db.Database.GetPendingMigrations().Any())
                    {
                        db.Database.Migrate();
                    }

                }

            }

            // Add services to the container.
            builder.Services.AddRazorPages();

            #region Extensions/TeknoRomaServices
            //builder.Services.AddScoped(typeof(IManager<>), typeof(Manager<>)); 
            #endregion

            // Add services to the container.
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            string constr = builder.Configuration.GetConnectionString("Constr");
            builder.Services.AddDbContext<AppDbContext>(p => p.UseNpgsql(constr));

            builder.Services.AddIdentity<AppUser, IdentityRole>(p =>
            {
                p.Password.RequireDigit = false;//Password icerisinde Sayisal deger olsun mu ?
                p.Password.RequireNonAlphanumeric = false;//!*$ gibi karajter girilmesi zorunlu olsun mu
                p.Password.RequireUppercase = false; // Buyuk Harf olsun mu 
                p.Password.RequireLowercase = false;//Kucuk Harf olsun mu ?
                p.Password.RequiredLength = 3;// En az 3 karakter olmaz zorunda

                p.User.RequireUniqueEmail = false;//Ayni mail adresinden birden fazla olmasin

                p.SignIn.RequireConfirmedPhoneNumber = false;
                p.SignIn.RequireConfirmedEmail = false;
                p.SignIn.RequireConfirmedAccount = false;


            })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

            builder.Services.AddTeknoRomaServices();
            builder.Services.AddNotyf(config =>
            {
                config.DurationInSeconds = 3;
                config.IsDismissable = true;

                config.Position = NotyfPosition.BottomRight;

            });

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

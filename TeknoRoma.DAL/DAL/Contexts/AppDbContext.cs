using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TeknoRoma.Entities.Entities.Abstract;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.DAL.DAL.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        // DbSets for Entities
        public DbSet<Birim> Birimler { get; set; }
        public DbSet<Cari> Cariler { get; set; }
        public DbSet<Departman> Departmanlar { get; set; }
        public DbSet<Depo> Depolar { get; set; }
        public DbSet<Doviz> Dovizler { get; set; }
        public DbSet<Fatura> Faturalar { get; set; }
        public DbSet<FaturaDetay> FaturaDetaylari { get; set; }
        public DbSet<Kasa> Kasalar { get; set; }
        public DbSet<KasaHareket> KasaHareketleri { get; set; }
        public DbSet<TeknoRoma.Entities.Entities.Concrete.Kategori> Kategoriler { get; set; }
        public DbSet<KullaniciYorum> KullaniciYorumlari { get; set; }
        public DbSet<Kur> Kurlar { get; set; }
        public DbSet<Menu> Menuler { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<SatisDetay> SatisDetaylari { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Stok> Stoklar { get; set; }
        public DbSet<StokBarkod> StokBarkodlari { get; set; }
        public DbSet<StokFotograf> StokFotograflari { get; set; }
        public DbSet<StokHareket> StokHareketleri { get; set; }
        public DbSet<Sube> Subeler { get; set; }
        public DbSet<Tedarikci> Tedarikciler { get; set; }
        public DbSet<AppUser> Kullanicilar { get; set; }

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(@"server=127.0.0.1;User Id=postgres;password=qweasd;Database=TeknoRoma");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Burasi calismak zorunda. Cunku Identity'nin ihtiyac dusdugu tablolar olusmazs 

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified)
                .ToList();

            foreach (var entity in entities)
            {
                if (entity.Entity is BaseEntity baseEntity)
                {
                    var now = DateTime.UtcNow;
                    if (entity.State == EntityState.Added)
                    {
                        baseEntity.CreatedAt = now;
                    }
                    else
                    {
                        baseEntity.UpdateAt = now;
                    }
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified)
                .ToList();

            foreach (var entity in entities)
            {
                if (entity.Entity is BaseEntity baseEntity)
                {
                    var now = DateTime.UtcNow;
                    if (entity.State == EntityState.Added)
                    {
                        baseEntity.CreatedAt = now;
                    }
                    else
                    {
                        baseEntity.UpdateAt = now;
                    }
                }
            }


            return base.SaveChanges();

        }

    }
}

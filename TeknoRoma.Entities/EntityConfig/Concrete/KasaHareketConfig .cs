using Microsoft.EntityFrameworkCore;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Entities.EntityConfig
{
    public class KasaHareketConfig : BaseConfig<KasaHareket>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<KasaHareket> builder)
        {
            base.Configure(builder);

            builder.ToTable("KasaHareketler");

            builder.Property(kh => kh.HareketTipi)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(kh => kh.Giris)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired(false);

            builder.Property(kh => kh.Cikis)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired(false);

            builder.Property(kh => kh.Tutar)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired(false);

            builder.Property(kh => kh.Tarih)
                   .HasColumnType("datetime2")
                   .IsRequired(false);

            builder.HasOne(kh => kh.Kasa)
                   .WithMany(k => k.KasaHareketleri)
                   .HasForeignKey(kh => kh.KasaId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(kh => kh.Doviz)
                   .WithMany(d => d.KasaHareketleri)
                   .HasForeignKey(kh => kh.DovizId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

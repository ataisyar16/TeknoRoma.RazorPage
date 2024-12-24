using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeknoRoma.Entities.Entities.Concrete;
using TeknoRoma.Entities.EntityConfig;

namespace TeknoRoma.Entities.EntityConfig.Concrete
{
    public class SiparisDetayConfig : BaseConfig<SiparisDetay>
    {
        public override void Configure(EntityTypeBuilder<SiparisDetay> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.SiparisId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.StokId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Miktar)
                .IsRequired();

            builder.Property(x => x.BirimFiyat)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // İlişkiler
            builder.HasOne(x => x.Siparis)
                .WithMany(x => x.SiparisDetaylari)
                .HasForeignKey(x => x.SiparisId);

            builder.HasOne(x => x.Stok)
                .WithMany(x => x.SiparisDetaylari)
                .HasForeignKey(x => x.StokId);

            // Tablo adı tanımlama
            builder.ToTable("SiparisDetaylari");
        }
    }
}

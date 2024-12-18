using Microsoft.EntityFrameworkCore;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Entities.EntityConfig
{
    public class SatisDetayConfig : BaseConfig<SatisDetay>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SatisDetay> builder)
        {
            base.Configure(builder);

            builder.ToTable("SatisDetaylari");

            builder.Property(sd => sd.Miktar)
                   .IsRequired();

            builder.Property(sd => sd.BirimFiyat)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.HasOne(sd => sd.Satis)
                   .WithMany(s => s.SatisDetaylari)
                   .HasForeignKey(sd => sd.SatisId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(sd => sd.Stok)
                   .WithMany(s => s.SatisDetaylari)
                   .HasForeignKey(sd => sd.StokId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

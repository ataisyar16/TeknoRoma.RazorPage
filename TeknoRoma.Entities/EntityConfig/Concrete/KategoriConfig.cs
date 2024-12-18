using Microsoft.EntityFrameworkCore;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Entities.EntityConfig
{
    public class KategoriConfig : BaseConfig<Kategori>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Kategori> builder)
        {
            base.Configure(builder);

            builder.ToTable("Kategoriler");

            builder.Property(k => k.KategoriAdi)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.HasMany(k => k.Stoklar)
                   .WithOne()
                   .HasForeignKey(s => s.Id)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

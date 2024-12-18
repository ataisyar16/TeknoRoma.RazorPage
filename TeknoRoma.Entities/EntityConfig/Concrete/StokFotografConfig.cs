using Microsoft.EntityFrameworkCore;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Entities.EntityConfig
{
    public class StokFotografConfig : BaseConfig<StokFotograf>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<StokFotograf> builder)
        {
            base.Configure(builder);

            builder.ToTable("StokFotograflar");

            builder.Property(sf => sf.FotografYolu)
                   .HasMaxLength(250)
                   .IsRequired(false);

            builder.HasOne(sf => sf.Stok)
                   .WithMany(s => s.StokFotograflari)
                   .HasForeignKey(sf => sf.StokId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

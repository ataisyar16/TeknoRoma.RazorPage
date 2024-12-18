using Microsoft.EntityFrameworkCore;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Entities.EntityConfig
{
    public class DepartmanConfig : BaseConfig<Departman>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Departman> builder)
        {
            base.Configure(builder);

            builder.ToTable("Departmanlar");

            builder.Property(d => d.DepartmanAdi)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.HasOne(d => d.UstDepartman)
                   .WithMany()
                   .HasForeignKey(d => d.UstId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(d => d.Personeller)
                   .WithOne(p => p.Departman)
                   .HasForeignKey(p => p.DepartmanId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

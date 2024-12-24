using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeknoRoma.Entities.Entities.Concrete;

namespace TeknoRoma.Entities.EntityConfig.Concrete
{
    public class MenuConfig : BaseConfig<Menu>
    {
        public override void Configure(EntityTypeBuilder<Menu> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.MenuAdi).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Page).HasMaxLength(50);
            builder.Property(p => p.Icon).HasMaxLength(50);
            builder.Property(p => p.Controller).HasMaxLength(50);
            builder.Property(p => p.Action).HasMaxLength(50);
            builder.Property(p => p.Area).HasMaxLength(50);
            builder.Property(p => p.Title).HasMaxLength(50);
            builder.Property(p => p.Description).HasMaxLength(200);
            builder.Property(p => p.ParentId).HasMaxLength(50);
            builder.Property(p => p.Css).HasMaxLength(100);

        }
    }
}

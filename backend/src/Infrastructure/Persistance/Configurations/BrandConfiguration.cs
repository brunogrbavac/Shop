using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(x => x.BrandId);
            builder.Property(x => x.BrandId).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            //Auditable
            builder.Property(p => p.CreatedBy)
                .HasMaxLength(64)
                .IsUnicode()
                .IsRequired();

            builder.Property(p => p.LastModifiedBy)
                .HasMaxLength(64)
                .IsUnicode();

            builder.Property(p => p.Created)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getutcdate())");

            builder.Property(p => p.LastModified)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getutcdate())");

            //Seeders
            builder.HasData(
                new { BrandId = 1, Name = "Logitech", CreatedBy = "user", LastModifiedBy = "user" },
                new { BrandId = 2, Name = "Razer", CreatedBy = "user", LastModifiedBy = "user" });
        }
    }
}

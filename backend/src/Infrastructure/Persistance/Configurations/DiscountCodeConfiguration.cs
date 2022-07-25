using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations
{
    public class DiscountCodeConfiguration : IEntityTypeConfiguration<DiscountCode>
    {
        public void Configure(EntityTypeBuilder<DiscountCode> builder)
        {
            builder.HasKey(x => x.DiscountCodeId);

            builder.Property(x => x.DiscountCodeId).ValueGeneratedOnAdd();

            builder.Property(x => x.Code)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Discount)
                .IsRequired();

            builder.Property(x => x.OrderId)
                .HasDefaultValue(-1);

            builder.Property(x => x.Used)
                //.HasDefaultValueSql("FALSE")
                .IsRequired();


            //Auditable
            builder.Property(x => x.CreatedBy)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LastModifiedBy)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Created)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getutcdate())");

            builder.Property(x => x.LastModified)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getutcdate())");

            //Seeders
            builder.HasData(
                new { DiscountCodeId = 1, Code = "Logitech15", Discount =(float)15.0, Used= false, CreatedBy = "user", LastModifiedBy = "user", OrderId=0},
                new { DiscountCodeId = 2, Code = "Razer20", Discount = (float)20.0, Used = false, CreatedBy = "user", LastModifiedBy = "user", OrderId = 0 });
        }
    }
}

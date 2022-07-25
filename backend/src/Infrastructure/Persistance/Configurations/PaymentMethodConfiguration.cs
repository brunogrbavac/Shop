using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations
{
    internal class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(x => x.PaymentMethodId);
            builder.Property(x => x.PaymentMethodId).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(50)  
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
                new { PaymentMethodId = 1, Name = "Cash", CreatedBy = "user", LastModifiedBy = "user" },
                new { PaymentMethodId = 2, Name = "Card", CreatedBy = "user", LastModifiedBy = "user" });
        }
    }
}

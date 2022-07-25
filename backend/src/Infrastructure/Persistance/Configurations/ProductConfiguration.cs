using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x=>x.ProductId);

            builder.Property(x => x.ProductId).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .HasDefaultValueSql("0")
                .IsRequired();

            builder.HasOne(x => x.Brand)
                .WithMany(b => b.Products);

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
                new { ProductId = 1, Name = "Logitech G915", Description= "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",BrandId=1, Price= (float)100, Quantity = 5, CreatedBy = "user", LastModifiedBy = "user" },
                new { ProductId = 2, Name = "Razer Deathadder", Description = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", BrandId = 2, Price = (float)50, Quantity = 5, CreatedBy = "user", LastModifiedBy = "user" },
                new { ProductId = 3, Name = "Logitech G915", Description = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", BrandId = 1, Price =(float) 100, Quantity = 15, CreatedBy = "user", LastModifiedBy = "user" },
                new { ProductId = 4, Name = "Razer Viper", Description = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", BrandId = 2, Price = (float)50, Quantity = 2, CreatedBy = "user", LastModifiedBy = "user" },
                new { ProductId = 5, Name = "Logitech G596", Description = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", BrandId = 1, Price = (float)100, Quantity = 3, CreatedBy = "user", LastModifiedBy = "user" },
                new { ProductId = 6, Name = "Razer Deathadder", Description = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", BrandId = 2, Price = (float)50, Quantity = 41, CreatedBy = "user", LastModifiedBy = "user" },
                new { ProductId = 7, Name = "Razer Deathadder", Description = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", BrandId = 2, Price = (float)350, Quantity = 1, CreatedBy = "user", LastModifiedBy = "user" },
                new { ProductId = 8, Name = "Logitech MX Keys", Description = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", BrandId = 1, Price = (float)250, Quantity = 2, CreatedBy = "user", LastModifiedBy = "user" },
                new { ProductId = 9, Name = "Razer Deathadder", Description = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", BrandId = 2, Price = (float)50, Quantity = 16, CreatedBy = "user", LastModifiedBy = "user" },
                new { ProductId = 10, Name = "Logitech G703", Description = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", BrandId = 1, Price = (float)150, Quantity = 0, CreatedBy = "user", LastModifiedBy = "user" },
                new { ProductId = 11, Name = "Razer Deathadder", Description = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", BrandId = 2, Price = (float)50, Quantity = 5, CreatedBy = "user", LastModifiedBy = "user" });
        }
    }
}

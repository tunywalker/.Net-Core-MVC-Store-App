using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
                builder.HasKey(p=>p.ProductId);
                builder.Property(p=>p.ProductName).IsRequired();
                builder.Property(p=>p.Price).IsRequired();
                builder.HasData(
                new Product() { ProductId = 1, CategoryId = 2,ImageUrl="/images/1.jpg", ProductName = "Computer", Price = 17_000,ShowCase=false },
                new Product() { ProductId = 2, CategoryId = 2,ImageUrl="/images/2.jpg", ProductName = "Keyboard", Price = 1_000,ShowCase=false },
                new Product() { ProductId = 3, CategoryId = 2,ImageUrl="/images/3.jpg", ProductName = "Mouse", Price = 500,ShowCase=false },
                new Product() { ProductId = 4, CategoryId = 2,ImageUrl="/images/4.jpg", ProductName = "Monitor", Price = 7_000,ShowCase=false },
                new Product() { ProductId = 5, CategoryId = 1,ImageUrl="/images/5.jpg", ProductName = "History", Price = 17_000,ShowCase=false },
                new Product() { ProductId = 6, CategoryId = 1,ImageUrl="/images/6.jpg", ProductName = "Hamlet", Price = 17_000,ShowCase=false },
                new Product() { ProductId = 7, CategoryId = 2,ImageUrl="/images/7.jpg", ProductName = "Xp-Pen", Price = 1150,ShowCase=true },
                new Product() { ProductId = 8, CategoryId = 1,ImageUrl="/images/8.jpg", ProductName = "Samsung Galaxy FE", Price = 4445,ShowCase=true },
                new Product() { ProductId = 9, CategoryId = 2,ImageUrl="/images/9.jpg", ProductName = "Wordpress ENVATO Theme", Price = 877,ShowCase=true }
                

                );
        }
    }
}
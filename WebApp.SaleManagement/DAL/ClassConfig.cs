using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.Models;

namespace WebApp.SaleManagement.DAL
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(k => k.Id);

        }

    }
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasOne(c => c.Category).WithMany(k => k.Products).HasForeignKey(c => c.CategoryId);
            builder.HasOne(c => c.Brand).WithMany(k => k.Products).HasForeignKey(c => c.BrandId);
        }

    }
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasOne(c => c.Customer).WithMany(k => k.Orders).HasForeignKey(c => c.CustomerId);

        }

    }
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasOne(o => o.Order).WithMany(d => d.OrderDetails).HasForeignKey(k => k.OrderId);
            builder.HasOne(p => p.Product).WithMany(d => d.OrderDetails).HasForeignKey(k => k.ProductId);

        }

    }
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasIndex(u => u.Email).IsUnique();
        }

    }
    public class BrandConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(k => k.Id);
        }
    }
}

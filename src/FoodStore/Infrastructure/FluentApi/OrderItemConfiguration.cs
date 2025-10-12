using FoodStore.Infrastructure.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStore.Infrastructure.FluentApi;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => new { x.OrderId, x.FoodId });
        builder.HasOne(x => x.Order).WithMany(x => x.OrderItems);
        builder.HasOne(x => x.Food);
        builder.OwnsOne(x => x.UnitPrice, money =>
        {
            money.Property(x => x.Amount).HasColumnName("UnitPrice");
            money.Property(x => x.Currency).HasColumnName("Currency");
        });
    }
}

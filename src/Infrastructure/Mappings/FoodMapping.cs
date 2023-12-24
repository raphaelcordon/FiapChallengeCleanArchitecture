using Domain.Entities.Food;
using Domain.Entities.ThirdPartyRegister;
using Domain.Enums.Food;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class FoodMapping : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        builder.ToTable(nameof(Food));

        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnType("GUID");

        builder.Property(p => p.FoodName)
            .IsRequired()
            .HasColumnName("FoodName")
            .HasConversion(
                v => v.Name,
                v => new FoodName(v));
        
        builder.Property(p => p.State)
            .IsRequired()
            .HasColumnName("State")
            .HasConversion(
                v => v.ToString(),
                v => (State)Enum.Parse(typeof(State), v));
        
        builder.Property(p => p.IsPerishable)
            .IsRequired()
            .HasColumnName("IsPerishable")
            .HasColumnType("BOOL");

        builder.Property(p => p.ExpirationDate)
            .IsRequired()
            .HasColumnName("ExpirationDate")
            .HasColumnType("DATE");
    }
}
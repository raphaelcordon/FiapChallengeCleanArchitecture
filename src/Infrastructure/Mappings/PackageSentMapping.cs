using Domain.Entities.Package;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class PackageSentMapping : IEntityTypeConfiguration<PackageSent>
{
    public void Configure(EntityTypeBuilder<PackageSent> builder)
    {
        builder.ToTable(nameof(PackageSent));

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnType("GUID");

        builder.Property(p => p.FoodList)
            .HasConversion(
                v => string.Join(";", v),
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .Select(Guid.Parse).ToList())
            .IsRequired()
            .HasColumnType("TEXT");

        builder.Property(p => p.PackageCreation)
            .IsRequired()
            .HasColumnType("DATETIME");

        builder.Property(p => p.ReceiverId)
            .IsRequired()
            .HasColumnType("GUID");
    }
}
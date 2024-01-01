using Domain.Entities.Package;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class PackageReceivedMapping : IEntityTypeConfiguration<PackageReceived>
{
    public void Configure(EntityTypeBuilder<PackageReceived> builder)
    {
        builder.ToTable(nameof(PackageReceived));

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

        builder.Property(p => p.DonorId)
            .IsRequired()
            .HasColumnType("GUID");
    }
}
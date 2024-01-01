using Domain.Entities.ThirdPartyRegister;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class ReceiverMapping : IEntityTypeConfiguration<Receiver>
{
    public void Configure(EntityTypeBuilder<Receiver> builder)
    {
        builder.ToTable(nameof(Receiver));

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnType("GUID");

        builder.Property(p => p.Name)
            .IsRequired()
            .HasConversion(
                v => v.Name,
                v => new ThirdPartyName(v));

        builder.Property(p => p.IsCompany)
            .IsRequired()
            .HasColumnType("BOOL");
    }
}
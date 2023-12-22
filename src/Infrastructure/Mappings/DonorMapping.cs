using Domain.Entities.ThirdPartyRegister;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class DonorMapping : IEntityTypeConfiguration<Donor>
{
    public void Configure(EntityTypeBuilder<Donor> builder)
    {
        builder.ToTable(nameof(Donor));

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnType("GUID");

        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasConversion(
                v => v.Name,
                v => new ThirdPartyName(v));
        
        builder.Property(p => p.IsCompany)
            .IsRequired()
            .HasColumnName("IsCompany")
            .HasColumnType("BOOL");
    }
}
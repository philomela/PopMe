using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReceiverService.Domain.Core;

namespace ReceiverService.Infrastructure.EntityTypeConfigurations;

internal class ReceiverConfiguration : IEntityTypeConfiguration<Receiver>
{
    public void Configure(EntityTypeBuilder<Receiver> builder)
    {
        builder.ToTable(nameof(Receiver));
        builder.HasOne(p => p.Meme)
               .WithOne(m => m.Receiver)
               .HasForeignKey<Meme>(m => m.Id);
        builder.Property(p => p.PhoneNumber);
        builder.Property(p => p.BirthDate);
        builder.Property(p => p.Name);
        builder.Property(p => p.UniqKey);
    }
}
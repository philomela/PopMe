using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PresenterService.Domain.Core;

namespace PresenterService.Infrastructure.EntityTypeConfigurations;

internal class PresenterConfiguration : IEntityTypeConfiguration<Presenter>
{
    public void Configure(EntityTypeBuilder<Presenter> builder)
    {
        builder.ToTable(nameof(Presenter));
        builder.HasOne(p => p.Meme)
               .WithOne(m => m.Presenter)
               .HasForeignKey<Meme>(m => m.Id);
        builder.Property(p => p.Name);
        builder.Property(p => p.PhoneNumber);
        builder.Property(p => p.UniqKey);
    }
}
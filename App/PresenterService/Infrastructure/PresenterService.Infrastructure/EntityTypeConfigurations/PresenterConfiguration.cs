using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PresenterService.Domain.Core;

namespace PresenterService.Infrastructure.EntityTypeConfigurations;

internal class PresenterConfiguration : IEntityTypeConfiguration<Presenter>
{
    public void Configure(EntityTypeBuilder<Presenter> builder)
    {
        builder.ToTable(nameof(Presenter));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name);
        //builder.HasOne(p => p.Meme)
        //       .WithOne(m => m.Presenter)
        //       .HasForeignKey<Meme>(m => m.PresenterId);
    }
}
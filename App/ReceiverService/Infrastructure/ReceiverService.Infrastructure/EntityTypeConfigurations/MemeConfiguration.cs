using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReceiverService.Domain.Core;

namespace ReceiverService.Infrastructure.EntityTypeConfigurations;

internal class MemeConfiguration : IEntityTypeConfiguration<Meme>
{
    public void Configure(EntityTypeBuilder<Meme> builder)
    {
        builder.ToTable(nameof(Meme));
        builder.HasKey(m => m.Id);
        builder.Property(m => m.TextСongratulations);
        builder.Property(m => m.VideoId);
    }
}
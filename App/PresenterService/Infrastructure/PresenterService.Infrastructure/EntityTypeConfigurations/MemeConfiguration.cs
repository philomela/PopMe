using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PresenterService.Domain.Core;

namespace PresenterService.Infrastructure.EntityTypeConfigurations;

/*internal class MemeConfiguration : IEntityTypeConfiguration<Meme>
{
    public void Configure(EntityTypeBuilder<Meme> builder)
    {
        builder.ToTable(nameof(Meme));
        builder.HasKey(m => m.Id);
    }
}
*/
using AdminService.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminService.Infrastructure.EntityTypeConfigurations;

internal class PairQrCodesConfiguration : IEntityTypeConfiguration<PairQrCodes>
{
    public void Configure(EntityTypeBuilder<PairQrCodes> builder)
    {
        builder.ToTable(nameof(PairQrCodes));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PresenterDataBase64);
        builder.Property(x => x.ReceiverDataBase64);
        builder.Property(x => x.UniqKey);
    }
}

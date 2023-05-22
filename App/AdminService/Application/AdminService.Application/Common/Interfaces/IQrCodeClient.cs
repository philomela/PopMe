using System.Drawing;

namespace AdminService.Application.Common.Interfaces;

public interface IQrCodeClient<T>
{
    public Task<T> GenerateQrCodeAsync(string data, CancellationToken token);
}

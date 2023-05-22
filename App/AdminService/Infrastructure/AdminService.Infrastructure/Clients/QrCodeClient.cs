using AdminService.Application.Common.Interfaces;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

namespace AdminService.Infrastructure.Clients;

public class QrCodeClient : IQrCodeClient<string>
{
    private readonly IConfiguration _configuration;
    public QrCodeClient(IConfiguration configuration) => _configuration = configuration;

    public async Task<string> GenerateQrCodeAsync(string data, CancellationToken token)
    {
        var result = await $"{_configuration["ExternalAddresses:QrCodeGeneration"]}{data}"
            .WithHeader("Accept", "image/png").GetBytesAsync();

        return Convert.ToBase64String(result);
    }
}
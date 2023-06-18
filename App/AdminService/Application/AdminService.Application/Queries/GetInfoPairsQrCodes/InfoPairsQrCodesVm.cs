using AdminService.Application.Common.Mappings;
using AdminService.Application.Queries.GetPairQrCodes;
using AdminService.Domain.Core;
using AutoMapper;

namespace AdminService.Application.Queries.GetInfoPairsQrCodes;

public class InfoPairsQrCodesVm : IMapFrom<InfoPairsQrCodesDto>
{
    public long CountPairsQrCodes { get; set; }

    public DateTime LastDateTimeCreated { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<InfoPairsQrCodesDto, InfoPairsQrCodesVm>()
            .ForMember(vm => vm.CountPairsQrCodes,
                opt => opt.MapFrom(m => m.CountPairsQrCodes))
            .ForMember(vm => vm.LastDateTimeCreated,
                opt => opt.MapFrom(m => m.LastDateTimeCreated));
    }
}

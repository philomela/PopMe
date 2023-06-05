using AdminService.Application.Common.Mappings;
using AdminService.Domain.Core;
using AutoMapper;

namespace AdminService.Application.Queries.GetPairQrCodes;

public class PairQrCodesVm : IMapFrom<PairQrCodes>
{
    public string PresenterQrCodeImg { get; set; }

    public string ReceiverQrCodeImg { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PairQrCodes, PairQrCodesVm>()
            .ForMember(vm => vm.PresenterQrCodeImg,
                opt => opt.MapFrom(m => m.PresenterDataBase64))
            .ForMember(vm => vm.ReceiverQrCodeImg,
                opt => opt.MapFrom(m => m.ReceiverDataBase64));
    }
}

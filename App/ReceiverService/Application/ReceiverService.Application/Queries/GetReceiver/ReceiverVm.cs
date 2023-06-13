using AutoMapper;
using ReceiverService.Application.Common.Mappings;
using ReceiverService.Domain.Core;

namespace ReceiverService.Application.Queries.GetReceiver;

public class ReceiverVm : IMapFrom<Receiver>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTime BirthDate { get; set; }

    public string PhoneNumber { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Receiver, ReceiverVm>()
        .ForMember(vm => vm.Id,
            opt => opt.MapFrom(m => m.Id))
        .ForMember(vm => vm.Name,
            opt => opt.MapFrom(m => m.Name))
        .ForMember(vm => vm.BirthDate,
            opt => opt.MapFrom(m => m.BirthDate))
        .ForMember(vm => vm.PhoneNumber,
            opt => opt.MapFrom(m => m.PhoneNumber));
    }
}

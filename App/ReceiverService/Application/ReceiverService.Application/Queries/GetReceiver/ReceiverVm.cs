using AutoMapper;
using ReceiverService.Application.Common.Mappings;
using ReceiverService.Domain.Core;

namespace ReceiverService.Application.Queries.GetReceiver;

public class ReceiverVm : IMapFrom<Receiver>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTime SurpriseDate { get; set; }

    public string PhoneNumber { get; set; }

    public string VideoId { get; set; }

    public string TextСongratulations { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Receiver, ReceiverVm>()
        .ForMember(vm => vm.Id,
            opt => opt.MapFrom(m => m.Id))
        .ForMember(vm => vm.Name,
            opt => opt.MapFrom(m => m.Name))
        .ForMember(vm => vm.SurpriseDate,
            opt => opt.MapFrom(m => m.SurpriseDate))
        .ForMember(vm => vm.PhoneNumber,
            opt => opt.MapFrom(m => m.PhoneNumber))
        .ForMember(vm => vm.VideoId,
            opt => opt.MapFrom(m => m.Meme.VideoId))
        .ForMember(vm => vm.TextСongratulations,
            opt => opt.MapFrom(m => m.Meme.TextСongratulations));
    }
}

using AutoMapper;
using PresenterService.Application.Common.Mappings;
using PresenterService.Domain.Core;

namespace PresenterService.Application.Queries.GetPresenter;

public class PresenterVm : IMapFrom<Presenter>
{
    public Guid Id { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Presenter, PresenterVm>()
        .ForMember(vm => vm.Id,
            opt => opt.MapFrom(m => m.Id));
    }
}

using AutoMapper;
using NueraApp.Api.ViewModel;
using NueraApp.Domain.Models;

namespace NueraApp.Api.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ContentLimitCategory, ContentLimitCategoryViewModel>();
            CreateMap<ContentLimitItem, ContentLimitItemViewModel>()
                .ForMember(dest => dest.ContentLimitCategoryId, opt => opt.MapFrom(src => src.ContentLimitCategoryId)); ;
        }        
    }
}

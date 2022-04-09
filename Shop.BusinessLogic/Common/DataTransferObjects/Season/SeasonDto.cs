using System;
using AutoMapper;
using Store.BusinessLogic.Common.Mappings;

namespace Store.BusinessLogic.Common.DataTransferObjects.Season
{
    public class SeasonDto : IMapWith<DAL.Entities.Season>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DAL.Entities.Season, SeasonDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(s => s.Title));
        }
    }
}
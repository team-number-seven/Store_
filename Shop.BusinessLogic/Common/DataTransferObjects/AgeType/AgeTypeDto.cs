using System;
using AutoMapper;
using Store.BusinessLogic.Common.Mappings;

namespace Store.BusinessLogic.Common.DataTransferObjects.AgeType
{
    public class AgeTypeDto : IMapWith<DAL.Entities.AgeType>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DAL.Entities.AgeType, AgeTypeDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(s => s.Title));
        }
    }
}
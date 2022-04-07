using System;
using AutoMapper;
using Store.BusinessLogic.Common.Mappings;

namespace Store.BusinessLogic.Common.DataTransferObjects.Gender
{
    public class GenderDto : IMapWith<DAL.Entities.Gender>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DAL.Entities.Gender, GenderDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(g => g.Id))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(g => g.Title));
        }
    }
}
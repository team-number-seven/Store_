using System;
using AutoMapper;
using Store.BusinessLogic.Common.Mappings;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class GenderDto : IMapWith<Gender>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Gender, GenderDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(g => g.Id))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(g => g.Title));
        }
    }
}
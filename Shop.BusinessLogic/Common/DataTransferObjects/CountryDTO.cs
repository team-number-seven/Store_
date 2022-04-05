using System;
using AutoMapper;
using Store.BusinessLogic.Common.Mappings;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class CountryDto : IMapWith<Country>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Country, CountryDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(c => c.Name));
        }
    }
}
using System;
using AutoMapper;
using Store.BusinessLogic.Common.Mappings;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class CountryDTO : IMapWith<Country>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Country, CountryDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(c => c.Id.ToString()))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(c => c.Name));
        }
    }
}
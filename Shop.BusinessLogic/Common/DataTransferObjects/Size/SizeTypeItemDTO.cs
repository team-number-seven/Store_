using System;
using AutoMapper;
using Store.BusinessLogic.Common.Mappings;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Common.DataTransferObjects.Size
{
    public class SizeTypeItemDto : IMapWith<SizeTypeItem>
    {
        public Guid Id { get; set; }
        public string Size { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SizeTypeItem, SizeTypeItemDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dto => dto.Size, opt => opt.MapFrom(s => s.Size));
        }
    }
}
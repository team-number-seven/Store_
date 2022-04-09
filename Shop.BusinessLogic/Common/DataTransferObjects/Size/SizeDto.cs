using System;
using AutoMapper;
using Store.BusinessLogic.Common.Mappings;

namespace Store.BusinessLogic.Common.DataTransferObjects.Size
{
    public class SizeDto : IMapWith<DAL.Entities.Size>
    {
        public Guid Id { get; set; }
        public string Size { get; set; }
        public string Standard { get; set; }
        public string ItemType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DAL.Entities.Size, SizeDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dto => dto.Size, opt => opt.MapFrom(s => s.Value))
                .ForMember(dto=>dto.Standard,opt=>opt.MapFrom(s=>s.Standard))
                .ForMember(dto=>dto.ItemType,opt=>opt.MapFrom(s=>s.ItemType.Title));
        }
    }
}
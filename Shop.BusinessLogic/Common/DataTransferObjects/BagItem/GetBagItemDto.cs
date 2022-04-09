using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Common.Mappings;

namespace Store.BusinessLogic.Common.DataTransferObjects.BagItem
{
    public class GetBagItemDto : IMapWith<DAL.Entities.BagItem>
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string Standard { get; set; }
        public string SubType { get; set; }
        public string Size { get; set; }
        public uint Count { get; set; }
        public FileContentResult Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DAL.Entities.BagItem, GetBagItemDto>()
                .ForMember(dto => dto.Brand, opt => opt.MapFrom(b => b.Item.Brand.Title))
                .ForMember(dto => dto.Count, opt => opt.MapFrom(b => b.Amount))
                .ForMember(dto => dto.Price, opt => opt.MapFrom(b => b.Item.Price))
                .ForMember(dto => dto.Size, opt => opt.MapFrom(b => b.Size.Value))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(b => b.Id))
                .ForMember(dto => dto.Standard, opt => opt.MapFrom(b => b.Size.Standard))
                .ForMember(dto => dto.SubType, opt => opt.MapFrom(b => b.Item.Characteristic.SubType.Title))
                .ForMember(dto => dto.Image, opt => opt.Ignore());
        }
    }
}
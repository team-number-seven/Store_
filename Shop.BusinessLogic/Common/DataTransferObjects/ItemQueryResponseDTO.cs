using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Common.Mappings;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class ItemQueryResponseDto : IMapWith<Item>
    {
        public Guid Id { get; set; }
        public string Price { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public FileContentResult Image { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Item, ItemQueryResponseDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dto => dto.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(dto => dto.Brand, opt => opt.MapFrom(s => s.Brand.Title))
                .ForMember(dto => dto.Color, opt => opt.MapFrom(s => s.CharacteristicItem.Color.Title))
                .ForMember(dto => dto.Type, opt => opt.MapFrom(s => s.CharacteristicItem.ItemType.Title))
                .ForMember(dto => dto.SubType, opt => opt.MapFrom(s => s.CharacteristicItem.SubItemType.Title))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(dto => dto.Image, opt => opt.Ignore());
        }
    }
}
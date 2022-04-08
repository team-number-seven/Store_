using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Common.Mappings;

namespace Store.BusinessLogic.Common.DataTransferObjects.Item
{

    //TODO FIX QUERY
    public class ItemDto : IMapWith<DAL.Entities.Item>
    {
        public Guid Id { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string ArticleNumber { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string AgeType { get; set; }
        public string Season { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public IList<FileContentResult> Images { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DAL.Entities.Item, ItemDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dto => dto.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(dto => dto.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(dto => dto.ArticleNumber, opt => opt.MapFrom(s => s.ArticleNumber))
                .ForMember(dto => dto.Brand, opt => opt.MapFrom(s => s.Brand.Title))
                .ForMember(dto => dto.Color, opt => opt.MapFrom(s => s.CharacteristicItem.Color.Title))
                .ForMember(dto => dto.Size, opt => opt.Ignore())//TODO FIX IGNORE
                .ForMember(dto => dto.AgeType, opt => opt.MapFrom(s => s.CharacteristicItem.AgeTypeItem.Title))
                .ForMember(dto => dto.Season, opt => opt.MapFrom(s => s.CharacteristicItem.SeasonItem.Title))
                .ForMember(dto => dto.Gender, opt => opt.MapFrom(s => s.CharacteristicItem.Gender.Title))
                .ForMember(dto => dto.Type, opt => opt.MapFrom(s => s.CharacteristicItem.ItemType.Title))
                .ForMember(dto => dto.SubType, opt => opt.MapFrom(s => s.CharacteristicItem.SubItemType.Title))
                .ForMember(dto => dto.Images, opt => opt.Ignore());
        }
    }
}
using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Common.Mappings;

namespace Store.BusinessLogic.Common.DataTransferObjects.FavoriteItem
{
    public class GetFavoriteItemDto:IMapWith<DAL.Entities.FavoriteItem>
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string Standard { get; set; }
        public string SubType { get; set; }
        public FileContentResult Image { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DAL.Entities.FavoriteItem, GetFavoriteItemDto>()
                .ForMember(dto => dto.Brand, opt => opt.MapFrom(b => b.Item.Brand.Title))
                .ForMember(dto => dto.Price, opt => opt.MapFrom(b => b.Item.Price))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(b => b.Id))
                .ForMember(dto => dto.Standard, opt => opt.MapFrom(b => b.Item.Characteristic.ItemCountSizes.First().Size.Standard))
                .ForMember(dto => dto.SubType, opt => opt.MapFrom(b => b.Item.Characteristic.SubType.Title))
                .ForMember(dto => dto.Image, opt => opt.Ignore());
        }
    }
}

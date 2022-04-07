using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Store.BusinessLogic.Common.DataTransferObjects.SubItemType;
using Store.BusinessLogic.Common.Mappings;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Common.DataTransferObjects.ItemTypeAndSubType
{
    public class ItemTypeAndSubTypeDto : IMapWith<ItemType>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IList<SubItemTypeDto> SubItemTypes { get; set; } = new List<SubItemTypeDto>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ItemType, ItemTypeAndSubTypeDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(dto => dto.SubItemTypes,
                    opt => opt.MapFrom(s =>
                        s.SubItemTypes.Select(x => new SubItemTypeDto {Id = x.Id, Title = x.Title})));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Store.BusinessLogic.Common.Mappings;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class ItemTypeAndSubTypeDTO : IMapWith<ItemType>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IList<SubItemTypeDTO> SubItemTypes { get; set; } = new List<SubItemTypeDTO>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ItemType, ItemTypeAndSubTypeDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(dto => dto.SubItemTypes,
                    opt => opt.MapFrom(s =>
                        s.SubItemTypes.Select(x => new SubItemTypeDTO {Id = x.Id, Title = x.Title})));
        }
    }
}
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
    public class SizeTypeItemDTO:IMapWith<SizeTypeItem>
    {
        public string Id { get; set; }
        public string Size { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SizeTypeItem, SizeTypeItemDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(s => s.Id.ToString()))
                .ForMember(dto => dto.Size, opt => opt.MapFrom(s => s.Size));
        }
    }
}

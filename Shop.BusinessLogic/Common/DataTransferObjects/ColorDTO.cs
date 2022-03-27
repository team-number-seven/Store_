﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Store.BusinessLogic.Common.Mappings;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class ColorDTO : IMapWith<Color>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Color, ColorDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(s => s.Id.ToString()))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(s => s.Title));
        }
    }
}
﻿using System;
using AutoMapper;
using Store.BusinessLogic.Common.Mappings;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class AgeTypeItemDto : IMapWith<AgeTypeItem>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AgeTypeItem, AgeTypeItemDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(s => s.Title));
        }
    }
}
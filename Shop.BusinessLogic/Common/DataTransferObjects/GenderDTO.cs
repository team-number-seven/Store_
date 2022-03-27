﻿using System;
using AutoMapper;
using Store.BusinessLogic.Common.Mappings;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class GenderDTO : IMapWith<Gender>
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Gender, GenderDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(g => g.Id.ToString()))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(g => g.Title));
        }
    }
}
using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Common.Mappings;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class ItemCreateDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string CountItem { get; set; }

        public string Price { get; set; }

        public string ArticleNumber { get; set; }

        public Guid BrandId { get; set; }

        public Guid ColorId { get; set; }

        public Guid SizeTypeItemId { get; set; }

        public Guid AgeTypeItemId { get; set; }

        public Guid SeasonItemId { get; set; }

        public Guid GenderId { get; set; }

        public Guid ItemTypeId { get; set; }

        public Guid SubItemTypeId { get; set; }
        public IEnumerable<IFormFile> Files { get; set; }
    }
}
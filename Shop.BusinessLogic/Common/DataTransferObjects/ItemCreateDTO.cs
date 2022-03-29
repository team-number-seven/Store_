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

        [FromHeader] public string Title { get; set; }

        [FromHeader] public string Description { get; set; }

        [FromHeader] public string CountItem { get; set; }

        [FromHeader] public string Price { get; set; }

        [FromHeader] public string ArticleNumber { get; set; }

        [FromHeader] public Guid BrandId { get; set; }

        [FromHeader] public Guid ColorId { get; set; }

        [FromHeader] public Guid SizeTypeItemId { get; set; }

        [FromHeader] public Guid AgeTypeItemId { get; set; }

        [FromHeader] public Guid SeasonItemId { get; set; }

        [FromHeader] public Guid GenderId { get; set; }

        [FromHeader] public Guid ItemTypeId { get; set; }

        [FromHeader] public Guid SubItemTypeId { get; set; }

        public IList<IFormFile> Images { get; set; }
    }
}
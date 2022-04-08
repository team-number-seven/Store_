﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Common.Extensions
{
    //TODO FILTERS
    /*public static class QueryableExtensions
    {
        public static IQueryable<Item> FilterByGender(this IQueryable<Item> items, IList<Guid> gendersId)
        {
            return gendersId.IsNullOrEmpty()
                ? items
                : items.Where(i => gendersId.Contains(i.CharacteristicItem.GenderId));
        }

        public static IQueryable<Item> FilterByAge(this IQueryable<Item> items, Guid ageTypeId)
        {
            return ageTypeId.Equals(Guid.Empty)
                ? items
                : items.Where(i => i.CharacteristicItem.AgeTypeItemId == ageTypeId);
        }

        public static IQueryable<Item> FilterByBrands(this IQueryable<Item> items, IList<Guid> brandsId)
        {
            return brandsId.IsNullOrEmpty()
                ? items
                : items.Where(i => brandsId.Contains(i.BrandId));
        }

        public static IQueryable<Item> FilterByColors(this IQueryable<Item> items, IList<Guid> colorsId)
        {
            return colorsId.IsNullOrEmpty()
                ? items
                : items.Where(i => colorsId.Contains(i.CharacteristicItem.ColorId));
        }

        public static IQueryable<Item> FilterByItemType(this IQueryable<Item> items, IList<Guid> typesId)
        {
            return typesId.IsNullOrEmpty()
                ? items
                : items.Where(i => typesId.Contains(i.CharacteristicItem.ItemTypeId));
        }

        public static IQueryable<Item> FilterBySubTypes(this IQueryable<Item> items, IList<Guid> subTypesId)
        {
            return subTypesId.IsNullOrEmpty()
                ? items
                : items.Where(i => subTypesId.Contains(i.CharacteristicItem.SubTypeItemId));
        }

        public static IQueryable<Item> FilterBySeason(this IQueryable<Item> items, IList<Guid> seasonsId)
        {
            return seasonsId.IsNullOrEmpty()
                ? items
                : items.Where(i => seasonsId.Contains(i.CharacteristicItem.SeasonItemId));
        }

        public static IQueryable<Item> FilterByMaxPrice(this IQueryable<Item> items, decimal price)
        {
            return items.Where(i => i.Price <= price);
        }

        public static IQueryable<Item> FilterByMinPrice(this IQueryable<Item> items, decimal price)
        {
            return items.Where(i => i.Price >= price);
        }

        public static IQueryable<Item> FilterBySize(this IQueryable<Item> items, IList<Guid> sizesId)
        {
            return sizesId.IsNullOrEmpty()
                ? items
                : items.Where(i => sizesId.Contains(i.CharacteristicItem.SizeItemId));
        }
    }*/
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.IdentityModel.Tokens;
using Store.DAL.Entities;
using Guid = System.Guid;

namespace Store.BusinessLogic.Common.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<Item> FilterByGender(this IQueryable<Item> items, IList<Guid> gendersId)
        {
            if (gendersId.IsNullOrEmpty())
                return items;

            var filterItems = from item in items
                from genderId in gendersId
                where item.CharacteristicItem.GenderId == genderId
                select item;
            return filterItems;
        }

        public static IQueryable<Item> FilterByAge(this IQueryable<Item> items, Guid ageTypeId)
        {
            if (ageTypeId.Equals(Guid.Empty))
                return items;
            var filterItems = from item in items
                where item.CharacteristicItem.AgeTypeItemId == ageTypeId
                select item;
            return filterItems;
        }

        public static IQueryable<Item> FilterByBrands(this IQueryable<Item> items, IList<Guid> brandsId)
        {
            if (brandsId.IsNullOrEmpty())
                return items;
            var filterItems = from item in items
                from id in brandsId
                where item.BrandId == id
                select item;
            return filterItems;
        }

        public static IQueryable<Item> FilterByColors(this IQueryable<Item> items, IList<Guid> colorsId)
        {
            if (colorsId.IsNullOrEmpty())
                return items;
            var filterItems = from item in items
                from id in colorsId
                where item.CharacteristicItem.ColorId == id
                select item;
            return filterItems;
        }

        public static IQueryable<Item> FilterByItemType(this IQueryable<Item> items, IList<Guid> typesId)
        {
            if (typesId.IsNullOrEmpty())
                return items;
            var filterItems = from item in items
                from id in typesId
                where item.CharacteristicItem.ItemTypeId == id
                select item;
            return filterItems;
        }

        public static IQueryable<Item> FilterBySubTypes(this IQueryable<Item> items, IList<Guid> subTypesId)
        {
            if (subTypesId.IsNullOrEmpty())
                return items;
            var filterItems = from item in items
                from id in subTypesId
                where item.CharacteristicItem.SubTypeItemId == id
                select item;
            return filterItems;
        }

        public static IQueryable<Item> FilterBySeason(this IQueryable<Item> items, IList<Guid> seasonsId)
        {
            if (seasonsId.IsNullOrEmpty())
                return items;
            var filterItems = from item in items
                from id in seasonsId
                where item.CharacteristicItem.SeasonItemId == id
                select item;
            return filterItems;
        }

        public static IQueryable<Item> FilterByPrice(this IQueryable<Item> items, decimal price)
        {
            var filterItems = from item in items
                where item.Price < price
                select item;
            return filterItems;
        }

        public static IQueryable<Item> FilterBySize(this IQueryable<Item> items, IList<Guid> sizesId)
        {
            if (sizesId.IsNullOrEmpty())
                return items;
            var filterItems = from item in items 
                from id in sizesId 
                where item.CharacteristicItem.Id == id 
                select item;
            return filterItems;
        }
    }
}
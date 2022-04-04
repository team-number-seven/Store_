using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using Store.DAL.Entities;
using Guid = System.Guid;

namespace Store.BusinessLogic.Common.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<Item> FilterByGender(this IQueryable<Item> items, IList<Guid> gendersId)
        {
            return gendersId.IsNullOrEmpty()
                ? items
                : gendersId.Aggregate(items, (current, id) => current.Where(i => i.CharacteristicItem.ItemTypeId == id));
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
                : brandsId.Aggregate(items, (current, id) => current.Where(i => i.BrandId == id));
        }

        public static IQueryable<Item> FilterByColors(this IQueryable<Item> items, IList<Guid> colorsId)
        {
            return colorsId.IsNullOrEmpty()
                ? items
                : colorsId.Aggregate(items, (current, id) => current.Where(i => i.CharacteristicItem.ColorId == id));
        }

        public static IQueryable<Item> FilterByItemType(this IQueryable<Item> items, IList<Guid> typesId)
        {
            return typesId.IsNullOrEmpty()
                ? items
                : typesId.Aggregate(items, (current, id) => current.Where(i => i.CharacteristicItem.ItemTypeId == id));
        }

        public static IQueryable<Item> FilterBySubTypes(this IQueryable<Item> items, IList<Guid> subTypesId)
        {
            return subTypesId.IsNullOrEmpty()
                ? items
                : subTypesId.Aggregate(items,
                    (current, id) => current.Where(i => i.CharacteristicItem.SubTypeItemId == id));
        }

        public static IQueryable<Item> FilterBySeason(this IQueryable<Item> items, IList<Guid> seasonsId)
        {
            return seasonsId.IsNullOrEmpty()
                ? items
                : seasonsId.Aggregate(items,
                    (current, id) => current.Where(i => i.CharacteristicItem.SeasonItemId == id));
        }

        public static IQueryable<Item> FilterByPrice(this IQueryable<Item> items, decimal price)
        {
            items = items.Where(i => i.Price <= price);
            return items;
        }

        public static IQueryable<Item> FilterBySize(this IQueryable<Item> items, IList<Guid> sizesId)
        {
            return sizesId.IsNullOrEmpty()
                ? items
                : sizesId.Aggregate(items, (current, id) => current.Where(i => i.CharacteristicItem.SizeItemId == id));
        }
    }
}
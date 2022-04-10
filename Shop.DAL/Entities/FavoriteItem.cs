using System;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class FavoriteItem:IBaseEntity
    {
        public Guid Id { get; set; }

        public virtual User User { get; set; }
        public Guid UserId { get; set; }

        public virtual Item Item { get; set; }
        public Guid ItemId { get; set; }
    }
}

using System;

namespace Store.DAL.Interfaces
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
    }
}
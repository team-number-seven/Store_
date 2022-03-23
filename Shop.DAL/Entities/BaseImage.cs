using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class BaseImage : IBaseEntity
    {
        public string Path { get; set; }
        public Guid ImageFormatId { get; set; }
        public ImageFormat ImageFormat { get; set; }
        public Guid Id { get; set; }
    }
}
using System;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class Logo : BaseImage
    {
        public Brand Brand { get; set; }
    }
}
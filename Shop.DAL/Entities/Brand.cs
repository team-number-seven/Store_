﻿using System;
using System.Collections.Generic;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Entities
{
    public class Brand : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public IEnumerable<Item> Items { get; set; }

        public Logo Logo { get; set; }
        public Guid LogoId { get; set; }
    }
}
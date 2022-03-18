﻿using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class Color : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}
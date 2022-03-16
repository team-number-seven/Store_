﻿using System;
using System.Collections.Generic;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Entities
{
    public class Gender : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
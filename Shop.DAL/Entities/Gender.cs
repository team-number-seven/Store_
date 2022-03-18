﻿using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class Gender : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
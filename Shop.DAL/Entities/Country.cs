﻿using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class Country : IBaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<Item> Items { get; set; }

        public IEnumerable<User> Users { get; set; }
        public Guid Id { get; set; }
    }
}
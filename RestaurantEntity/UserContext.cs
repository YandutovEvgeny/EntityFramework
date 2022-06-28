﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEntity
{
    class UserContext : DbContext
    {
        public UserContext() : base("DefaultConnection")
        {

        }
        public DbSet<User> Users { get; set; }  //Наша таблица
    }
}

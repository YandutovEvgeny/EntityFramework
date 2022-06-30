using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantEntity.Models
{
    class Menu
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Photo { get; set; }
    }
}

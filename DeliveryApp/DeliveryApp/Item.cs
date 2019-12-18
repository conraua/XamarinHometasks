using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryApp
{
    public class Item
    {
        public Item(string Name_, string Image_, int Count_, int Category_, int Price_)
        {
            Name = Name_;
            Image = Image_;
            Count = Count_;
            Category = Category_;
            Price = Price_;
        }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Count { get; set; }
        public int Category { get; set; }
        public int Price { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreList.Models
{
    public class Item
    {
        public LiteDB.ObjectId _id { get; set; }
        public string name { get; set; } //Name of item
        public string location { get; set; } //location of item
        public LiteDB.ObjectId catID { get; set; } //category
        public int quantity { get; set; } //Quantity of the item
        public string categoryName { get; set; }

        public Item(string Name, string Loc, int Quantity)
        {
            name = Name;
            location = Loc;
            quantity = Quantity;
        }

        public Item()
        {
        }

        public override string ToString()
        {
            return "Name = " + name + " location = " + location + " Quantity = " + quantity;
        }
    }
}

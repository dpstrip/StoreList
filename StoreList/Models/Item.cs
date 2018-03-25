using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreList.Models
{
    public class Item
    {
        public LiteDB.ObjectId _id { get; set; }
        string name { get; set; } //Name of item
        string location { get; set; } //location of item
        Category cat { get; set; } //category
        int quantity { get; set; } //Quantity of the item
    }
}

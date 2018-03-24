using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreList.Models
{
    public class Category
    {
        public LiteDB.ObjectId _id { get; set; }
        public string category { get; set; }
    }
}

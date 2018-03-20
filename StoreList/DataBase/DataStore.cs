using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;


namespace StoreList.DataBase
{
    public class DataStore
    {
        public LiteRepository db;
      
        public DataStore(string name)
        {
            db = new LiteRepository(name);
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using StoreList.Models;

namespace StoreList.DataBase
{
    public class DataStore
    {
        public LiteDatabase db;
        public LiteCollection<Category> catCollection;

        public DataStore()
        {
            db = new LiteDatabase(@"C:\dstrash\dblite\StoreList");
            catCollection = db.GetCollection<Category>("Category");
        }


        public void createCategory(Category cat)
        {          
            catCollection.Insert(cat);
        }

        public List<Category> readCategory()
        {
            List<Category> cats = catCollection.FindAll().ToList<Category>();

            foreach(Category cat in cats)
            {
                Console.WriteLine("{0}, {1}", cat._id, cat.category);
            }

            return cats;
        }

        public void updateCategory(Category cat)
        {
            catCollection.Update(cat);
        }

        public void deleteCategory(Category cat)
        {
            catCollection.Delete(cat._id);
        }
        
    }
}

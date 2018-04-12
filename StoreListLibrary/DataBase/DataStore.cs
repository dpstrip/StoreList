using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public LiteCollection<Item> itemCollection;

        public DataStore()
        {
            db = new LiteDatabase(@"StoreList");
            catCollection = db.GetCollection<Category>("Category");
            itemCollection = db.GetCollection<Item>("Item");
        }

        #region category
        public void createCategory(Category cat)
        {          
            catCollection.Insert(cat);
        }

        public List<Category> readCategory()
        {
            List<Category> cats = catCollection.FindAll().ToList<Category>();
            consolePrintCategory(cats);
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

        private void consolePrintCategory(List<Category> cats)
        {
            foreach (Category cat in cats)
            {
                Console.WriteLine("In readCat: {0}, {1}", cat._id, cat.category);
            }
        }
        #endregion
        #region itemRegion
        public void insertItem(Item it)
        {
            itemCollection.Insert(it);
        }

        public List<Item> readItems()
        {
            List<Item> items = itemCollection.FindAll().ToList<Item>();
            consolePrintItems(items);
            return items;
        }

        private void consolePrintItems(List<Item> items)
        {
            foreach (Item it in items)
            {
                Console.WriteLine("In readItems: {0}, {1}, {2}, {3}, {4}", it._id, it.name, it.location, it.quantity, it.catID);
            }
        }

        public void deleteItem(Item it)
        {
            itemCollection.Delete(it._id);
        }

        public void update(Item it)
        {
            itemCollection.Upsert(it);
        }


        #endregion
    }
}

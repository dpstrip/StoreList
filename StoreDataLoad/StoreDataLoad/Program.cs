using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreList.Models;
using Microsoft.VisualBasic.FileIO;
using StoreList.DataBase;

namespace StoreDataLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\dpstr\Desktop\ListData.csv";
            DataStore ds = new DataStore();
            try
            {
                List<string> list = new List<string>();
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        list.Add(sr.ReadLine()); //Using readline method to read text file.
                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    string[] strlist = list[i].Split(','); //using string.split() method to split the string.
                    Item item = new Item(strlist[0], null, Convert.ToInt32(strlist[1]));
                    Console.WriteLine(item.ToString());
                    //If you want to insert it into database, you could insert from here.
                    ds.insertItem(item);
                }

            }
             
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            finally
            {
                Console.ReadKey();
            }

        }


    }
}

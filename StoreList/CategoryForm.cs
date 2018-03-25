using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreList.Models;

namespace StoreList
{
    public partial class CategoryForm : Form
    {
        public DataBase.DataStore CatDb;
        public List<Category> cats;
        private Category currentCat;



        public CategoryForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            CatDb = new DataBase.DataStore();
            loadListBox();
        }

        private void loadListBox()
        {
            cats = CatDb.readCategory();
            listBox1.DataSource = cats;
            listBox1.DisplayMember = "Category";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add a new item in category
            Category _curCat = new Category();
            _curCat.category = textBox1.Text;
            currentCat = _curCat;
            CatDb.createCategory(currentCat);
            loadListBox();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCat = (Category)listBox1.SelectedItem;
            textBox1.Text = currentCat.category;
            Console.WriteLine("In ListBox Selected: {0}, {1}", currentCat._id, currentCat.category);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Update button
            currentCat.category = textBox1.Text;
            Console.WriteLine("In Update: {0}, {1}", currentCat._id, currentCat.category);
            CatDb.updateCategory(currentCat);
            loadListBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete button
            Console.WriteLine("In delete: {0}, {1}", currentCat._id, currentCat.category);
            CatDb.deleteCategory(currentCat);
            loadListBox();

        }
    }
}

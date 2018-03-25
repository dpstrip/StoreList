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
            Category cat = new Category();
            cat.category = textBox1.Text;
            CatDb.createCategory(cat);
            CatDb.readCategory();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCat = (Category)listBox1.SelectedItem;
            textBox1.Text = currentCat.category;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Update button
            currentCat.category = textBox1.Text;
            CatDb.updateCategory(currentCat);
            loadListBox();
        }
    }
}

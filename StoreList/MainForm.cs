using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiteDB;
using StoreList.DataBase;
using StoreList.Models;


namespace StoreList
{
    public partial class MainForm : Form
    {
        public DataStore db = new DataStore();
        public BindingList<Category> catList;
        public BindingList<Item> itemList;
        int currentRow;

        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryForm popup = new CategoryForm();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                Console.WriteLine("You clicked OK");
            }
            else if (dialogresult == DialogResult.Cancel)
            {
                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
            popup.Dispose();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Create 3 items for the list
            catList = new BindingList<Category>(db.readCategory());
            itemList = new BindingList<Item>(db.readItems());
            setDataGrid();
            setCombo();
        }

        private void setCombo()
        {
            comboBox1.DataSource = catList;
            comboBox1.DisplayMember = "category";
            comboBox1.ValueMember = "_id";
        }

        private void setDataGrid()
        { 
            dataGridView1.DataSource = itemList;
            dataGridView1.Columns["name"].HeaderText = "Name";
            dataGridView1.Columns["location"].HeaderText = "Location";
            dataGridView1.Columns["quantity"].HeaderText = "Quantity";
            dataGridView1.Columns["categoryName"].HeaderText = "Category";

            dataGridView1.Columns["_id"].Visible = false;
            dataGridView1.Columns["catID"].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[3].Value;    
            currentRow = dataGridView1.CurrentRow.Index;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Add
            Item it = new Item();
            FillItem(it);    
            itemList.Add(it);
            dataGridView1.Refresh();
            setDataGrid();
            db.insertItem(it);
        }

        private void FillItem(Item it)
        {
            it.name = textBox1.Text;
            it.location = textBox2.Text;
            it.quantity = Convert.ToInt32(textBox3.Text);
            Category lCat = (Category)comboBox1.SelectedItem;
            it.categoryName = lCat.category;
            it.catID = lCat._id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update
            Item it = itemList[currentRow];
            FillItem(it);
            dataGridView1.Refresh();
            setDataGrid();
            db.update(it);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Delete item
            Item it = itemList[currentRow];
            itemList.Remove(it);
            dataGridView1.Refresh();
            setDataGrid();
            db.deleteItem(it);
        }
    }
}

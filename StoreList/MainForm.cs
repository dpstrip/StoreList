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
            //Category cate = catList.ElementAt<Category>(1);
            //Item it = new Item { name = "cookies", location = "Top Shelf", quantity = 2, catID = cate._id };
            //Item it2 = new Item { name = "milk", location = "Fridge", quantity = 5, catID = catList.ElementAt<Category>(0)._id };
            //Item it3 = new Item { name = "Chips", location = "Top of shelf", quantity = 25, catID = catList.ElementAt<Category>(0)._id };
            //db.insertItem(it);
            //db.insertItem(it2);
            //db.insertItem(it3);

        }

        private void setDataGrid()
        { 
            //Binding the comboBox to the a the list of values of Category
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.DataSource = catList;
            combo.DisplayMember = "category";
            combo.ValueMember = "_id";
            combo.HeaderText = "Category";
            combo.DataPropertyName = "catID";


            dataGridView1.Columns.Add(combo);


            dataGridView1.DataSource = itemList;
            dataGridView1.Columns["name"].HeaderText = "Name";
            dataGridView1.Columns["location"].HeaderText = "Location";
            dataGridView1.Columns["quantity"].HeaderText = "Quantity";
           // Console.WriteLine(dataGridView1.Columns["cat"].DataPropertyName = "cat.category";

            //dataGridView1.Columns.Insert(3, combo);//works but not in the cat column

            dataGridView1.Columns["_id"].Visible = false;



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            currentRow = dataGridView1.CurrentRow.Index;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Item it = new Item();
            itemList.Add(it);
            //dataGridView1.Refresh();
            //setDataGrid();
            dataGridView1.Rows.Add();
        }
    }
}

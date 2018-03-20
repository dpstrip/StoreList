using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreList
{
    public partial class CategoryForm : Form
    {
        public DataBase.DataStore CatDb;
        public string databaseName = "Category";

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
            CatDb = new DataBase.DataStore(databaseName);
        }
    }
}

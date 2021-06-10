using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace AdventureWorksSalesForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            insertIntoCategoryComboBox();
        }

        private void insertIntoCategoryComboBox()
        {
            List<Category> categories = DataAccess.returnCategories();

            foreach (Category category in categories)
            {
                categoryComboBox.Items.Add(category.ToString());
                
            }
            
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

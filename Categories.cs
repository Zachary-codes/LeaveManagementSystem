using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeaveManagementSystem
{
    public partial class Categories : Form
    {
        Functions Con;
        public Categories()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCategories();
        }
        private void ShowCategories()
        {
            string Query = "select * from CategoryTbl";
            CategoriesList.DataSource = Con.GetData(Query);
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(CapNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data!");
                }else
                {
                    string Category = CapNameTb.Text;
                    string Query = "insert into CategoryTbl values('{0}')";
                    Query = string.Format(Query, Category);
                    Con.SetData(Query);
                    ShowCategories();
                    CapNameTb.Text = "";

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}

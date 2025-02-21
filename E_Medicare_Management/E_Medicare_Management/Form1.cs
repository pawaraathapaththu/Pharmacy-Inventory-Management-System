using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace E_Medicare_Management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=RVmedicare;Integrated Security=True");

        private void lblStaff_Click(object sender, EventArgs e)
        {
           /* panelCategory.Visible = false;
            panelProduct.Visible = false;
            panelCustomer.Visible = false;
            panelOrder.Visible = false;
            panelStaff.Visible = true;*/
        }

        private void lblCategoryAd_Click(object sender, EventArgs e)
        {
            
           /* panelProduct.Visible = false;
            panelCustomer.Visible = false;
            panelOrder.Visible = false;
            panelStaff.Visible = false;
            panelCategory.Visible = true;*/
        }

        private void lblProductAd_Click(object sender, EventArgs e)
        {
            /*panelCategory.Visible = false;
            panelProduct.Visible = true;
            panelCustomer.Visible = false;
            panelOrder.Visible = false;
            panelStaff.Visible = false;*/
        }

        private void lblCustomerAd_Click(object sender, EventArgs e)
        {
           /* panelCategory.Visible = false;
            panelProduct.Visible = false;
            panelCustomer.Visible = true;
            panelOrder.Visible = false;
            panelStaff.Visible = false;*/
        }

        private void lblOrderAd_Click(object sender, EventArgs e)
        {
           /* panelCategory.Visible = false;
            panelProduct.Visible = false;
            panelCustomer.Visible = false;
           panelOrder.Visible = true;
            panelStaff.Visible = false;*/
        }

        private void uAdd_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace E_Medicare_Management
{
    public partial class E_MEd : Form
    {
        dba db;
        public static DataTable st = new DataTable();
        public static DataTable ct = new DataTable();
        public static DataTable catt = new DataTable();
        public static DataTable pt = new DataTable();
        public static DataTable tab = new DataTable();

        public static string CategoryName;
        public static string Role;
       // public static string username, password;
        

        public static ArrayList Cat = new ArrayList();
        public static ArrayList stff = new ArrayList();

        

        int flag;
        int stock;
        int uprice, totprice, qty;
        string product;
        int num = 0;
        string cname;
        int sum = 0;
       
       private int count = 0;

       void updateproduct()
        {

            int id = Convert.ToInt32(dgvorder.CurrentRow.Cells[0].Value.ToString());
            int newQty = stock - Convert.ToInt32(txtorderedquantity.Text);
            if (newQty < 0)
            {
                MessageBox.Show("Operation Failed");

            }
            else
            {
                db.cud("update Product set Quantity = " + newQty + " where ProductCode = " + id + ";");
                pt.Clear();
                db.ProdctTable("select * from Product");
                dgvcatogory.DataSource = pt;
            }
        }
        void staffrefresh()
        {
            st.Clear();
            db.staffTable("select*from Staff");
            dgvstaff.DataSource = st;
        }
        void productrefresh()
        {
            pt.Clear();
            db.ProdctTable("select*from Product");
            dgvproduct.DataSource = pt;
        }


        private void lblStaff_Click(object sender, EventArgs e)
        {
            panelStaff.Visible = true;
            panelcustomer.Visible = false;
            panelCategory.Visible = false;
            panelProduct.Visible = false;
            panelOrder.Visible = false;

            cmbStaffsearch.Items.Clear();
            db.retrive("Select Role from Staff", "Staff");
            foreach (string rv in stff)
            {
               
                cmbStaffsearch.Items.Add(rv);
            }
            stff.Clear();
        }


        public E_MEd(string userRole)
        {
           

            InitializeComponent();
            db = new dba();
            
            db.staffTable("select * from Staff");
            db.customerTable("select * from Customer");
            dgvstaff.DataSource = st;
            dgvCus.DataSource = ct;
            db.CategoryTable("select * from Category");
            dgvCategory.DataSource = catt;
            db.ProdctTable("select * from Product");
            dgvproduct.DataSource = pt;
            dgvcatogory.DataSource = pt;
            dgvcusto.DataSource = ct;

            db = new dba();
            panelStaff.Visible = false;
            panelcustomer.Visible = false;
            panelCategory.Visible = false;
            panelProduct.Visible = false;
            panelOrder.Visible = false;

            if (userRole == "Pharmacist")
            {
                lblStaff.Visible = false;
                lblCustomerAd.Visible = false;
                lblOrderAd.Visible = false;

            }
            else if (userRole == "Accountant")
            {
                lblStaff.Visible = false;
                lblCustomerAd.Visible = false;
                lblProductAd.Visible = false;
                lblCategoryAd.Visible = false;

            }
            else if (userRole == "Assistant")
            {
                lblStaff.Visible = false;
                lblProductAd.Visible = false;
                lblCategoryAd.Visible = false;
                lblOrderAd.Visible = false;
            }

        }


        private void lblCategoryAd_Click(object sender, EventArgs e)
        {
            panelCategory.BringToFront();
            panelCategory.Visible = true;
            panelStaff.Visible = false;
            panelcustomer.Visible = false;
            panelProduct.Visible = false;
            panelOrder.Visible = false;
        }


        private void lblCustomerAd_Click(object sender, EventArgs e)
        {
            panelcustomer.BringToFront();
            panelcustomer.Visible = true;
            panelStaff.Visible = false;
            panelCategory.Visible = false;
            panelOrder.Visible = false;
            panelProduct.Visible = false;
        }

        private void btnCatAdd_Click_1(object sender, EventArgs e)
        {
            db.cud("Insert into Category(CategoryCode, CategoryName) values('" + txtCategoryCode.Text + "','" +txtCategoryName.Text + "')");
            catt.Clear();
            db.CategoryTable("select * from Category");
            dgvCategory.DataSource = catt;
        }

 

        private void lblCatDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you need to delete","Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                db.cud("delete from Category where CategoryCode = '" + txtCategoryCode.Text + "'");
                catt.Clear();
                db.CategoryTable("select * from Category");
                dgvCategory.DataSource = catt;
            }
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var demo = dgvCategory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            string s = demo.ToString();
            txtCategoryCode.Text = dgvCategory.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCategoryName.Text = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
            
        }
        
        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            db.cud("Insert into Product(ProductCode, ProductName, ProductPrice, Quantity, ProductDescription, Category) values(" + txtProuctCode.Text + ",'" + txtProductName.Text + "'," + txtProductPrice.Text + "," + txtQuantity.Text + ",'" + txtProDec.Text + "','" + cmbCat.GetItemText(cmbCat.SelectedItem) + "')");
            pt.Clear();
            db.ProdctTable("select * from Product");
            dgvproduct.DataSource = pt;
        }

        private void lblProductAd_Click(object sender, EventArgs e)
        {
            panelProduct.BringToFront();
            panelProduct.Visible = true;
            panelStaff.Visible = false;
            panelcustomer.Visible = false;
            panelCategory.Visible = false;
            panelOrder.Visible = false;

            cmbCat.Items.Clear();
            cmbSearch.Items.Clear();
            db.retrive("Select CategoryName from Category", "Category");
            foreach(string rv in Cat)
            {
                cmbCat.Items.Add(rv);
                cmbSearch.Items.Add(rv);
            }
            Cat.Clear();
            
        }

        private void lblSerch_Click(object sender, EventArgs e)
        {
            pt.Clear();
            db.ProdctTable("Select*from Product where CategoryCode ='" + cmbSearch.Text + "'");
            dgvproduct.DataSource = pt;
        }



        private void btnStaffSearch_Click(object sender, EventArgs e)
        {
           ////////////////////////////////
        }

        private void btnProductEdit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you need to Edit", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                db.cud("update Product set    ProductName ='" + txtProductName.Text + "',ProductPrice=" + txtProductPrice.Text + ",Quantity=" + txtQuantity.Text + ",ProductDescription='" + txtProDec.Text + "',CategoryCode='" + cmbCat.GetItemText(cmbCat.SelectedItem) + "'where ProductCode=" + txtProuctCode.Text);
            pt.Clear();
            db.ProdctTable("select * from Product");
            dgvproduct.DataSource = pt;
        }
        }

        private void dgvproduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var prod = dgvproduct.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            string s = prod.ToString();
            txtProuctCode.Text = dgvproduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtProductName.Text  = dgvproduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtProductPrice.Text = dgvproduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtQuantity.Text = dgvproduct.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtProDec.Text = dgvproduct.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtCategoryCode.Text = dgvproduct.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void lblRefresh_Click(object sender, EventArgs e)
        {
            productrefresh();
        }

        private void lblLogAd_Click(object sender, EventArgs e)
        {
            this.Close();
            Login log = new Login();
            log.Show();

        }

        private void lblCusAdd_Click_1(object sender, EventArgs e)
        {
            db.cud("Insert into Customer(CustomerName, CustomerContact, CustomerAddress) values('" + txtCustomerName.Text + "'," + txtCustomerPhone.Text + ",'" + txtCustomerAddress.Text + "')");
            ct.Clear();
            db.customerTable("select * from Customer");
            dgvCus.DataSource = ct;
        }

        private void dgvCus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var demo = dgvCus.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            string s = demo.ToString();
            txtCustomerName.Text = dgvCus.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCustomerPhone.Text = dgvCus.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCustomerAddress.Text = dgvCus.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void lblCusEdit_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you need to Edit", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                db.cud("update Customer set   CustomerContact=" + txtCustomerPhone.Text + ", CustomerAddress='" + txtCustomerAddress.Text + "' where CustomerName='" + txtCustomerName.Text + "'");
                ct.Clear();
                db.customerTable("select * from Customer");
                dgvCus.DataSource = ct;
            }
        }

        private void lblCusDel_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you need to delete", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                db.cud("delete from Customer where CustomerName = '" + txtCustomerName.Text + "'");
                ct.Clear();
                db.customerTable("select * from Customer");
                dgvCus.DataSource = ct;
            }
        }

        private void lblOrderAd_Click(object sender, EventArgs e)
        {
            panelOrder.BringToFront();
            panelOrder.Visible = true;
            panelStaff.Visible = false;
            panelcustomer.Visible = false;
            panelCategory.Visible = false;
            panelProduct.Visible = false;
          

            cmboderedCat.Items.Clear();
            db.retrive("Select CategoryName from Category", "Category");
            foreach (string rv in Cat)
            {
                cmboderedCat.Items.Add(rv);
                
            }
            Cat.Clear();
            if (count == 0)
            {
                count++;
                tab.Columns.Add("Num", typeof(int));
                tab.Columns.Add("Product", typeof(string));
                tab.Columns.Add("Quantity", typeof(int));
                tab.Columns.Add("UnitPrice", typeof(int));
                tab.Columns.Add("TotPrice", typeof(int));


                dgvorder.DataSource = tab;
            }
        }


        private void dgvcatogory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            product = dgvcatogory.CurrentRow.Cells[0].Value.ToString();
            //qty = Convert.ToInt32(txtQty.Text);
            stock = Convert.ToInt32(dgvcatogory.CurrentRow.Cells[3].Value.ToString());
            uprice = Convert.ToInt32(dgvcatogory.CurrentRow.Cells[2].Value.ToString());
            //totprice = qty * uprice;
            txtoderedpId.Text = dgvcatogory.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtProname.Text = dgvcatogory.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtUnitPr.Text = dgvcatogory.Rows[e.RowIndex].Cells[2].Value.ToString();
            flag = 1;
        }

        private void dgvcusto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var demo = dgvcusto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            string s = demo.ToString();
            txtOrderedCusto.Text = dgvcusto.Rows[e.RowIndex].Cells[0].Value.ToString();

        }

        private void btnStaffRefresh_Click(object sender, EventArgs e)
        {
            ///////////////////////////////
        }


        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you need to delete", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes) { 
                db.cud("delete from Product where ProductCode = " + txtProuctCode.Text + "");
            pt.Clear();
            db.ProdctTable("select * from Product");
            dgvproduct.DataSource = pt;
        }
        }

        private void btnInsertorder_Click(object sender, EventArgs e)
        {
            if (txtOrderId.Text == "" || txtOrderedCusto.Text == "" || txtoderedpId.Text == "" || lblotalAmount.Text == "")
            {
                MessageBox.Show("Fill The Data Correctly");
            }
            else
            {
                try
                {
                  db.cud("Insert into Orders (OrderId, Quantity, Orderdate,CustmerName,Total,ProductName,UnitPrice) values(" + txtOrderId.Text + "," + txtorderedquantity.Text + ",'" +orderdate.Text + "','"+txtOrderedCusto.Text+"',"+lblotalAmount.Text+",'"+txtProname.Text+"',"+txtUnitPr.Text+")");
                 
                }
                catch
                {
                    MessageBox.Show("Oder Not Added");
                }
            }
        }

        private void label25_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvorder.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvorder.Rows[i].Cells[4].Value);
            }
            lblotalAmount.Text = sum.ToString();
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
             ViewOrderReport view = new ViewOrderReport();
            view.Show();
        }

        private void btnstaffdetails_Click(object sender, EventArgs e)
        {
          ////////////////////////
        }

        private void btnCategorEdit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you need to Edit", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                db.cud("update Category set    CategoryName='" + txtCategoryName.Text + "' where CategoryCode='" + txtCategoryCode.Text + "'");
            catt.Clear();
            db.CategoryTable("select * from Category");
            dgvCategory.DataSource = catt;
        }
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            db.cud("Insert into Staff(UserId, Username, Role, Contact, Password) values('" + txtUserID.Text + "','" + txtuser_s_name.Text + "','" + cmbDesignation.GetItemText(cmbDesignation.SelectedItem) + "'," + txtContact.Text + ",'" + txtPassword.Text + "')");
            st.Clear();
            db.staffTable("select * from Staff");
            dgvstaff.DataSource = st;
        }

        private void btnStaffEdit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you need to Edit", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                db.cud("update Staff set   Username= '" + txtuser_s_name.Text + "',Role='" + cmbDesignation.GetItemText(cmbDesignation.SelectedItem) + "', Contact=" + txtContact.Text + ",Password='" + txtPassword.Text + "'where UserId='" + txtUserID.Text + "'");
                st.Clear();
                db.staffTable("select * from Staff");
                dgvstaff.DataSource = st;
            }
        }

        private void btnStaffDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you need to delete", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                db.cud("delete from Staff where UserID = '" + txtUserID.Text + "'");
                st.Clear();
                db.staffTable("select * from Staff");
                dgvstaff.DataSource = st;
            }
        }

        private void btnStaffSearch_Click_1(object sender, EventArgs e)
        {
            st.Clear();
            db.staffTable("Select*from Staff where Role ='" + cmbStaffsearch.Text + "'");
            dgvstaff.DataSource = st;
        }

        private void lblStaffRefresh_Click(object sender, EventArgs e)
        {
            staffrefresh();
        }

        private void dgvstaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var staff = dgvstaff.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            string s = staff.ToString();
            txtUserID.Text = dgvstaff.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtuser_s_name.Text = dgvstaff.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbDesignation.SelectedItem = dgvstaff.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtContact.Text = dgvstaff.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPassword.Text = dgvstaff.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void E_MEd_Load(object sender, EventArgs e)
        {
            panelStaff.Visible = false;
            panelcustomer.Visible = false;
            panelCategory.Visible = false;
            panelProduct.Visible = false;
            panelOrder.Visible = false;
        }

        private void lblStaffReport_Click(object sender, EventArgs e)
        {
            StaffReport staff = new StaffReport();
            staff.Show();
        }

        private void lblProductReport_Click(object sender, EventArgs e)
        {
            Productreport prore = new Productreport();
            prore.Show();
        }

        private void dgvcatogory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            product = dgvcatogory.CurrentRow.Cells[0].Value.ToString();
            //qty = Convert.ToInt32(txtQty.Text);
            stock = Convert.ToInt32(dgvcatogory.CurrentRow.Cells[3].Value.ToString());
            uprice = Convert.ToInt32(dgvcatogory.CurrentRow.Cells[2].Value.ToString());
            //totprice = qty * uprice;
            txtoderedpId.Text = dgvcatogory.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtProname.Text = dgvcatogory.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtUnitPr.Text = dgvcatogory.Rows[e.RowIndex].Cells[2].Value.ToString();
            flag = 1;
        }

        private void dgvproduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var prod = dgvproduct.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            string s = prod.ToString();
            txtProuctCode.Text = dgvproduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtProductName.Text = dgvproduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtProductPrice.Text = dgvproduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtQuantity.Text = dgvproduct.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtProDec.Text = dgvproduct.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtCategoryCode.Text = dgvproduct.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var demo = dgvCategory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            string s = demo.ToString();
            txtCategoryCode.Text = dgvCategory.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCategoryName.Text = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void dgvCus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var demo = dgvCus.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            string s = demo.ToString();
            txtCustomerName.Text = dgvCus.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCustomerPhone.Text = dgvCus.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCustomerAddress.Text = dgvCus.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void lblAddOrder_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtorderedquantity.Text == "")
                {
                    MessageBox.Show("Enter The Quantity of Products");
                }
                else if (flag == 0)
                {
                    MessageBox.Show("Select The Product");
                }
                else if (Convert.ToInt32(txtorderedquantity.Text) > stock)
                {
                    MessageBox.Show("No Enough Stock Available");
                }
                else
                {
                    num = Convert.ToInt32(txtoderedpId.Text);
                    qty = Convert.ToInt32(txtorderedquantity.Text);
                    cname = txtOrderedCusto.Text;
                    totprice = qty * uprice;
                    tab.Rows.Add(num, product, qty, uprice, totprice);
                    dgvorder.DataSource = tab;
                    flag = 0;

                    updateproduct();
                }
            }
            catch
            {
                MessageBox.Show("Please check the order again");
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pt.Clear();
            db.ProdctTable("Select*from Product where CategoryCode ='" + cmboderedCat.Text + "'");
            dgvcatogory.DataSource = pt;
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Medicare_Management
{
    public partial class Productreport : Form
    {
        public Productreport()
        {
            InitializeComponent();
        }
        MySqlConnection Con = new MySqlConnection("server=localhost;database=medicare;username=root;password=Azone123");

        void populateoders()
        {
            try
            {
                Con.Open();
                string Myquery = "select * from Product";
                MySqlDataAdapter da = new MySqlDataAdapter(Myquery, Con);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                dgvViewProduct.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }

        }

        private void Productreport_Load(object sender, EventArgs e)
        {
             populateoders();
        }

        private void dgvViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("RV MEDICARE PRODUCT DETAILS", new Font("Century", 25, FontStyle.Bold), Brushes.Green, new Point(160, 10));
            e.Graphics.DrawString(DateTime.Now.ToString(), new Font("Century", 16, FontStyle.Regular), Brushes.Black, new Point(200, 50));
            e.Graphics.DrawString("______________________________________________________________________________________________________________________________________________________________________________________________ ", new Font("Century", 25, FontStyle.Bold), Brushes.Black, new Point(-120, 80));
            e.Graphics.DrawString("PRODUCT CODE-----------------: " + dgvViewProduct.CurrentRow.Cells[0].Value.ToString(), new Font("Century", 20, FontStyle.Regular), Brushes.Black, new Point(80, 180));
            e.Graphics.DrawString("PRODUCT NAME-----------------: " + dgvViewProduct.CurrentRow.Cells[1].Value.ToString(), new Font("Century", 20, FontStyle.Regular), Brushes.Black, new Point(80, 210));
            e.Graphics.DrawString("PRODUCT PRICE------------------: " + "Rs " + dgvViewProduct.CurrentRow.Cells[2].Value.ToString(), new Font("Century", 20, FontStyle.Regular), Brushes.Black, new Point(80, 240));
            e.Graphics.DrawString("QUANTITY-------------------------: " + dgvViewProduct.CurrentRow.Cells[3].Value.ToString() , new Font("Century", 20, FontStyle.Regular), Brushes.Black, new Point(80, 270));
            e.Graphics.DrawString("PRODUCT DESCRIPTION-----:" + dgvViewProduct.CurrentRow.Cells[4].Value.ToString(), new Font("Century", 20, FontStyle.Regular), Brushes.Black, new Point(80, 300));
            e.Graphics.DrawString("CATEGORY CODE----------------: " + dgvViewProduct.CurrentRow.Cells[5].Value.ToString(), new Font("Century", 20, FontStyle.Regular), Brushes.Black, new Point(80, 330));
            e.Graphics.DrawString("______________________________________________________________________________________________________________________________________________________________________________________________ ", new Font("Century", 25, FontStyle.Bold), Brushes.Black, new Point(-120, 400));
            e.Graphics.DrawString("RV MEDICARE ", new Font("Century", 25, FontStyle.Bold), Brushes.Green, new Point(230, 480));
            e.Graphics.DrawString("+", new Font("Forte", 85, FontStyle.Bold), Brushes.Red, new Point(400, 490));

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = printDocument1;

            DialogResult result = printDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog2.Document = printDocument2;
            int height = dgvViewProduct.Height;
            dgvViewProduct.Height = dgvViewProduct.RowCount * dgvViewProduct.RowTemplate.Height * 2;
            bmp = new Bitmap(dgvViewProduct.Width, dgvViewProduct.Height);
            dgvViewProduct.DrawToBitmap(bmp, new Rectangle(30, 10, dgvViewProduct.Width, dgvViewProduct.Height));
            dgvViewProduct.Height = height;
            printPreviewDialog2.ShowDialog();
        }

        Bitmap bmp;
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}

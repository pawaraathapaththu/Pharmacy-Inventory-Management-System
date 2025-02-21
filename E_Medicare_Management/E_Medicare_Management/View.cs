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
    public partial class ViewOrderReport : Form
    {
        public ViewOrderReport()
        {
            InitializeComponent();
        }
        MySqlConnection Con = new MySqlConnection("server=localhost;database=medicare;username=root;password=Azone123");

        public void populateoders()
        {
            try
            {
                Con.Open();
                string Myquery = "select * from Orders ";
                MySqlDataAdapter da = new MySqlDataAdapter(Myquery, Con);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                dgvVieworder.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }

        }

        private void dgvVieworder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ViewOrderReport_Load(object sender, EventArgs e)
        {
            populateoders();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("E MEDICARE ", new Font("Century", 25, FontStyle.Bold), Brushes.Green, new Point(185,10));
            e.Graphics.DrawString("+", new Font("Forte", 100, FontStyle.Bold), Brushes.Red, new Point(400, 10));
            e.Graphics.DrawString(DateTime.Now.ToString(), new Font("Century", 16, FontStyle.Regular), Brushes.Black, new Point(200,50));
            e.Graphics.DrawString("______________________________________________________________________________________________________________________________________________________________________________________________ ", new Font("Century", 25, FontStyle.Bold), Brushes.Black, new Point(-120, 90));
            e.Graphics.DrawString("CUSTOMER------------: " + dgvVieworder.CurrentRow.Cells[3].Value.ToString(), new Font("Century", 19, FontStyle.Regular), Brushes.Black, new Point(50, 180));
            e.Graphics.DrawString("ORDER DATE----------: " + dgvVieworder.CurrentRow.Cells[2].Value.ToString(), new Font("Century", 19, FontStyle.Regular), Brushes.Black, new Point(50, 210));
            e.Graphics.DrawString("PRODUCT---------------: " + dgvVieworder.CurrentRow.Cells[5].Value.ToString(), new Font("Century", 19, FontStyle.Regular), Brushes.Black, new Point(50, 240));
            e.Graphics.DrawString("UNIT PRICE------------: " + "Rs " + dgvVieworder.CurrentRow.Cells[6].Value.ToString(), new Font("Century", 19, FontStyle.Regular), Brushes.Black, new Point(50, 270));
            e.Graphics.DrawString("QUANTITY--------------: " + dgvVieworder.CurrentRow.Cells[1].Value.ToString(), new Font("Century", 19, FontStyle.Regular), Brushes.Black, new Point(50, 300));
            e.Graphics.DrawString("ORDER ID---------------: " + dgvVieworder.CurrentRow.Cells[0].Value.ToString(), new Font("Century", 19, FontStyle.Regular), Brushes.Black, new Point(50, 330));
            e.Graphics.DrawString("TOTA AMOUNT-----: " + "Rs " + dgvVieworder.CurrentRow.Cells[4].Value.ToString(), new Font("Century", 20, FontStyle.Regular), Brushes.Black, new Point(50, 360));
            e.Graphics.DrawString("_________________________________________________________________________________________________________________________________________________________________________________________________", new Font("Century", 25, FontStyle.Bold), Brushes.Black, new Point(-120, 400));
            e.Graphics.DrawString("Thank you, Come again! ", new Font("Century", 25, FontStyle.Bold), Brushes.Red, new Point(160, 480));
            e.Graphics.DrawString("Contact : 0702192322 | 0812219876, Fax : 0812219876, website : EMed.lk ", new Font("Century", 15, FontStyle.Regular), Brushes.Black, new Point(-7, 550));
            

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

            MessageBox.Show("Saved pdf");
        }

        private void txtfilterOrder_TextChanged(object sender, EventArgs e)
        {
            populateoders();
        }

        Bitmap bmp;

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog2.Document = printDocument2;
            int height = dgvVieworder.Height;
            dgvVieworder.Height = dgvVieworder.RowCount * dgvVieworder.RowTemplate.Height * 2;
            bmp = new Bitmap(dgvVieworder.Width, dgvVieworder.Height);
            dgvVieworder.DrawToBitmap(bmp, new Rectangle(30, 10, dgvVieworder.Width, dgvVieworder.Height));
            dgvVieworder.Height = height;
            printPreviewDialog2.ShowDialog();
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}

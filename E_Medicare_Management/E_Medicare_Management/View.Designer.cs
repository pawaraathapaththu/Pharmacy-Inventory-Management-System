
namespace E_Medicare_Management
{
    partial class ViewOrderReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewOrderReport));
            this.dgvVieworder = new System.Windows.Forms.DataGridView();
            this.btnview = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnprint = new System.Windows.Forms.Button();
            this.txtfilterOrder = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog2 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVieworder)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVieworder
            // 
            this.dgvVieworder.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgvVieworder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVieworder.GridColor = System.Drawing.Color.DarkGreen;
            this.dgvVieworder.Location = new System.Drawing.Point(12, 86);
            this.dgvVieworder.Name = "dgvVieworder";
            this.dgvVieworder.RowHeadersWidth = 51;
            this.dgvVieworder.RowTemplate.Height = 24;
            this.dgvVieworder.Size = new System.Drawing.Size(993, 354);
            this.dgvVieworder.TabIndex = 0;
            this.dgvVieworder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVieworder_CellClick);
            // 
            // btnview
            // 
            this.btnview.BackColor = System.Drawing.Color.SlateBlue;
            this.btnview.Font = new System.Drawing.Font("Elephant", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnview.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnview.Location = new System.Drawing.Point(12, 459);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(178, 49);
            this.btnview.TabIndex = 1;
            this.btnview.Text = "Close";
            this.btnview.UseVisualStyleBackColor = false;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.OriginAtMargins = true;
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.SlateBlue;
            this.btnprint.Font = new System.Drawing.Font("Elephant", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnprint.Location = new System.Drawing.Point(219, 459);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(178, 49);
            this.btnprint.TabIndex = 2;
            this.btnprint.Text = "Save pdf";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // txtfilterOrder
            // 
            this.txtfilterOrder.BackColor = System.Drawing.Color.FloralWhite;
            this.txtfilterOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtfilterOrder.Location = new System.Drawing.Point(194, 474);
            this.txtfilterOrder.Name = "txtfilterOrder";
            this.txtfilterOrder.Size = new System.Drawing.Size(10, 15);
            this.txtfilterOrder.TabIndex = 3;
            this.txtfilterOrder.TextChanged += new System.EventHandler(this.txtfilterOrder_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Elephant", 24F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(380, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(250, 53);
            this.label10.TabIndex = 4;
            this.label10.Text = "ORDERS ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SlateBlue;
            this.button1.Font = new System.Drawing.Font("Elephant", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(413, 459);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 49);
            this.button1.TabIndex = 5;
            this.button1.Text = "REPORT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // printDocument2
            // 
            this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
            // 
            // printPreviewDialog2
            // 
            this.printPreviewDialog2.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog2.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog2.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog2.Enabled = true;
            this.printPreviewDialog2.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog2.Icon")));
            this.printPreviewDialog2.Name = "printPreviewDialog2";
            this.printPreviewDialog2.Visible = false;
            // 
            // ViewOrderReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1021, 540);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtfilterOrder);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btnview);
            this.Controls.Add(this.dgvVieworder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewOrderReport";
            this.Text = "View";
            this.Load += new System.EventHandler(this.ViewOrderReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVieworder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVieworder;
        private System.Windows.Forms.Button btnview;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.TextBox txtfilterOrder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Drawing.Printing.PrintDocument printDocument2;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog2;
    }
}
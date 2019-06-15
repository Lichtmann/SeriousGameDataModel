namespace DataModel.ViewPage
{
    partial class PageSetHersteller
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bt_Set_volt = new System.Windows.Forms.Button();
            this.bt_Cabl = new System.Windows.Forms.Button();
            this.bt_Zeus_Machine = new System.Windows.Forms.Button();
            this.bt_Buy = new System.Windows.Forms.Button();
            this.rtb_Summary = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 29);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(187, 196);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Maschinen Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "Maschinen";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(205, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(723, 285);
            this.dataGridView1.TabIndex = 11;
            // 
            // bt_Set_volt
            // 
            this.bt_Set_volt.Location = new System.Drawing.Point(14, 231);
            this.bt_Set_volt.Name = "bt_Set_volt";
            this.bt_Set_volt.Size = new System.Drawing.Size(185, 23);
            this.bt_Set_volt.TabIndex = 12;
            this.bt_Set_volt.Text = "Set Voltmaster";
            this.bt_Set_volt.UseVisualStyleBackColor = true;
            this.bt_Set_volt.Click += new System.EventHandler(this.bt_Set_volt_Click);
            // 
            // bt_Cabl
            // 
            this.bt_Cabl.Location = new System.Drawing.Point(14, 260);
            this.bt_Cabl.Name = "bt_Cabl";
            this.bt_Cabl.Size = new System.Drawing.Size(185, 23);
            this.bt_Cabl.TabIndex = 13;
            this.bt_Cabl.Text = "Set Cablemachine";
            this.bt_Cabl.UseVisualStyleBackColor = true;
            this.bt_Cabl.Click += new System.EventHandler(this.bt_Cabl_Click);
            // 
            // bt_Zeus_Machine
            // 
            this.bt_Zeus_Machine.Location = new System.Drawing.Point(14, 291);
            this.bt_Zeus_Machine.Name = "bt_Zeus_Machine";
            this.bt_Zeus_Machine.Size = new System.Drawing.Size(185, 23);
            this.bt_Zeus_Machine.TabIndex = 14;
            this.bt_Zeus_Machine.Text = "Set Zeus_Machine";
            this.bt_Zeus_Machine.UseVisualStyleBackColor = true;
            this.bt_Zeus_Machine.Click += new System.EventHandler(this.bt_Zeus_Machine_Click);
            // 
            // bt_Buy
            // 
            this.bt_Buy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Buy.Location = new System.Drawing.Point(701, 415);
            this.bt_Buy.Name = "bt_Buy";
            this.bt_Buy.Size = new System.Drawing.Size(75, 23);
            this.bt_Buy.TabIndex = 15;
            this.bt_Buy.Text = "Ok";
            this.bt_Buy.UseVisualStyleBackColor = true;
            this.bt_Buy.Click += new System.EventHandler(this.bt_Ok_Click);
            // 
            // rtb_Summary
            // 
            this.rtb_Summary.Location = new System.Drawing.Point(205, 321);
            this.rtb_Summary.Name = "rtb_Summary";
            this.rtb_Summary.Size = new System.Drawing.Size(490, 96);
            this.rtb_Summary.TabIndex = 16;
            this.rtb_Summary.Text = "";
            // 
            // PageSetHersteller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtb_Summary);
            this.Controls.Add(this.bt_Buy);
            this.Controls.Add(this.bt_Zeus_Machine);
            this.Controls.Add(this.bt_Cabl);
            this.Controls.Add(this.bt_Set_volt);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "PageSetHersteller";
            this.Text = "PageSetHersteller";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bt_Set_volt;
        private System.Windows.Forms.Button bt_Cabl;
        private System.Windows.Forms.Button bt_Zeus_Machine;
        private System.Windows.Forms.Button bt_Buy;
        private System.Windows.Forms.RichTextBox rtb_Summary;
    }
}
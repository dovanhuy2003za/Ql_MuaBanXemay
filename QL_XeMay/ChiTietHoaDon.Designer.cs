namespace QL_XeMay
{
    partial class ChiTietHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChiTietHoaDon));
            groupBox1 = new GroupBox();
            dataGridView1 = new DataGridView();
            stt = new DataGridViewTextBoxColumn();
            mahd = new DataGridViewTextBoxColumn();
            id = new DataGridViewTextBoxColumn();
            nsx = new DataGridViewTextBoxColumn();
            sl = new DataGridViewTextBoxColumn();
            dongia = new DataGridViewTextBoxColumn();
            tt = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            textBox3 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBox4 = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Location = new Point(12, 252);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(924, 244);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách chi tiết hóa đơn";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { stt, mahd, id, nsx, sl, dongia, tt });
            dataGridView1.Location = new Point(22, 50);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(871, 188);
            dataGridView1.TabIndex = 0;
            // 
            // stt
            // 
            stt.DataPropertyName = "stt";
            stt.HeaderText = "STT";
            stt.MinimumWidth = 6;
            stt.Name = "stt";
            stt.Width = 50;
            // 
            // mahd
            // 
            mahd.DataPropertyName = "Mahd1";
            mahd.HeaderText = "Mã hóa đơn";
            mahd.MinimumWidth = 6;
            mahd.Name = "mahd";
            mahd.Width = 125;
            // 
            // id
            // 
            id.DataPropertyName = "TenSp";
            id.HeaderText = "Tên sản phẩm";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.Width = 125;
            // 
            // nsx
            // 
            nsx.DataPropertyName = "Nsx";
            nsx.HeaderText = "Nhà sản xuất";
            nsx.MinimumWidth = 6;
            nsx.Name = "nsx";
            nsx.Width = 125;
            // 
            // sl
            // 
            sl.DataPropertyName = "Soluongdat";
            sl.HeaderText = "Số lượng";
            sl.MinimumWidth = 6;
            sl.Name = "sl";
            sl.Width = 125;
            // 
            // dongia
            // 
            dongia.DataPropertyName = "dongia";
            dongia.HeaderText = "Đơn giá";
            dongia.MinimumWidth = 6;
            dongia.Name = "dongia";
            dongia.Width = 125;
            // 
            // tt
            // 
            tt.DataPropertyName = "thanhtien";
            tt.HeaderText = "Thành tiền";
            tt.MinimumWidth = 6;
            tt.Name = "tt";
            tt.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 101);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 1;
            label1.Text = "Mã sản phẩm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 151);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 2;
            label2.Text = "Số lượng";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(234, 148);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(234, 94);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(622, 29);
            button1.Name = "button1";
            button1.Size = new Size(94, 61);
            button1.TabIndex = 6;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(625, 111);
            button2.Name = "button2";
            button2.Size = new Size(94, 60);
            button2.TabIndex = 7;
            button2.Text = "Xóa";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(234, 46);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 46);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 9;
            label3.Text = "Mã hóa đơn";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(94, 209);
            label4.Name = "label4";
            label4.Size = new Size(163, 20);
            label4.TabIndex = 10;
            label4.Text = "Nhập số thư tự cần xóa";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(302, 212);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 11;
            // 
            // ChiTietHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PapayaWhip;
            ClientSize = new Size(948, 508);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ChiTietHoaDon";
            Text = "Chi tiết hóa đơn";
            Load += ChiTietHoaDon_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private TextBox textBox3;
        private Label label3;
        private Label label4;
        private TextBox textBox4;
        private DataGridViewTextBoxColumn stt;
        private DataGridViewTextBoxColumn mahd;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn nsx;
        private DataGridViewTextBoxColumn sl;
        private DataGridViewTextBoxColumn dongia;
        private DataGridViewTextBoxColumn tt;
    }
}
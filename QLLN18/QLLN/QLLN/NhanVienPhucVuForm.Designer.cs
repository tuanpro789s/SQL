namespace QLLN
{
    partial class NhanVienPhucVuForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.btnSum_MA = new Button();
            this.btnSum_Hd = new Button();
            this.listView1 = new ListView();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Seven Swordsmen BB", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = SystemColors.MenuHighlight;
            this.label1.Location = new Point(169, 31);
            this.label1.Name = "label1";
            this.label1.Size = new Size(411, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bảng Dành cho Nhân viên Phục Vụ";

            // btnSum_MA
            this.btnSum_MA.Location = new Point(73, 80);
            this.btnSum_MA.Name = "btnSum_MA";
            this.btnSum_MA.Size = new Size(131, 50);
            this.btnSum_MA.TabIndex = 1;
            this.btnSum_MA.Text = "Tổng Món Ăn";
            this.btnSum_MA.UseVisualStyleBackColor = true;
            this.btnSum_MA.Click += new EventHandler(this.btnSum_MA_Click);

            // btnSum_Hd
            this.btnSum_Hd.Location = new Point(244, 80);
            this.btnSum_Hd.Name = "btnSum_Hd";
            this.btnSum_Hd.Size = new Size(131, 50);
            this.btnSum_Hd.TabIndex = 2;
            this.btnSum_Hd.Text = "Tổng Hóa Đơn";
            this.btnSum_Hd.UseVisualStyleBackColor = true;
            this.btnSum_Hd.Click += new EventHandler(this.btnSum_Hd_Click);

            // listView1
            this.listView1.Location = new Point(73, 167);
            this.listView1.Name = "listView1";
            this.listView1.Size = new Size(573, 123);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = View.Details;
            this.listView1.Columns.Add("Hành Động", 200);
            this.listView1.Columns.Add("kết Quả", 100);

            // NhanVienPhucVuForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnSum_Hd);
            this.Controls.Add(this.btnSum_MA);
            this.Controls.Add(this.label1);
            this.Name = "NhanVienPhucVuForm";
            this.Text = "NhanVienPhucVuForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label label1;
        private Button btnSum_MA;
        private Button btnSum_Hd;
        private ListView listView1;
    }
}
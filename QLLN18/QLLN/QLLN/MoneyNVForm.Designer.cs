
namespace QLLN
{
    partial class MoneyNVForm
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
            label1 = new Label();
            btnHd = new Button();
            listView1 = new ListView();
            but = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Seven Swordsmen BB", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(177, 38);
            label1.Name = "label1";
            label1.Size = new Size(439, 23);
            label1.TabIndex = 0;
            label1.Text = "Bảng Dành Cho Nhân Viên Thu Ngân";
            // 
            // btnHd
            // 
            btnHd.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHd.Location = new Point(85, 78);
            btnHd.Name = "btnHd";
            btnHd.Size = new Size(261, 41);
            btnHd.TabIndex = 1;
            btnHd.Text = "Xem Dữ Liệu Hóa Đơn";
            btnHd.UseVisualStyleBackColor = true;
            btnHd.Click += btnHd_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(88, 141);
            listView1.Name = "listView1";
            listView1.Size = new Size(596, 201);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // but
            // 
            but.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            but.Location = new Point(396, 78);
            but.Name = "but";
            but.Size = new Size(288, 41);
            but.TabIndex = 3;
            but.Text = "Xem Dữ Liệu CT Hóa Đơn";
            but.UseVisualStyleBackColor = true;
            but.Click += btnCTHD_Click;
            // 
            // MoneyNVForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(but);
            Controls.Add(listView1);
            Controls.Add(btnHd);
            Controls.Add(label1);
            Name = "MoneyNVForm";
            Text = "MoneyNVForm";
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label label1;
        private Button btnHd;
        private ListView listView1;
        private Button but;
    }
}
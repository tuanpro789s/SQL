namespace QLLN
{
    partial class AdminForm
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
            this.lblQTV = new System.Windows.Forms.Label();
            this.gb_danhmuc = new System.Windows.Forms.GroupBox();
            this.txtTDM = new System.Windows.Forms.TextBox();
            this.txtMDM = new System.Windows.Forms.TextBox();
            this.lblTDM = new System.Windows.Forms.Label();
            this.lblMDM = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.group_DM = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.gb_danhmuc.SuspendLayout();
            this.group_DM.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblQTV
            // 
            this.lblQTV.AutoSize = true;
            this.lblQTV.Font = new System.Drawing.Font("Seven Swordsmen BB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQTV.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblQTV.Location = new System.Drawing.Point(178, 23);
            this.lblQTV.Name = "lblQTV";
            this.lblQTV.Size = new System.Drawing.Size(355, 23);
            this.lblQTV.TabIndex = 0;
            this.lblQTV.Text = "Bảng Dành cho Quản Trị Viên";
            // 
            // gb_danhmuc
            // 
            this.gb_danhmuc.Controls.Add(this.txtTDM);
            this.gb_danhmuc.Controls.Add(this.txtMDM);
            this.gb_danhmuc.Controls.Add(this.lblTDM);
            this.gb_danhmuc.Controls.Add(this.lblMDM);
            this.gb_danhmuc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_danhmuc.Location = new System.Drawing.Point(55, 63);
            this.gb_danhmuc.Name = "gb_danhmuc";
            this.gb_danhmuc.Size = new System.Drawing.Size(573, 134);
            this.gb_danhmuc.TabIndex = 1;
            this.gb_danhmuc.TabStop = false;
            this.gb_danhmuc.Text = "Nhập Thông tin Danh Mục";
            // 
            // txtTDM
            // 
            this.txtTDM.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTDM.Location = new System.Drawing.Point(142, 61);
            this.txtTDM.Name = "txtTDM";
            this.txtTDM.Size = new System.Drawing.Size(222, 26);
            this.txtTDM.TabIndex = 3;
            // 
            // txtMDM
            // 
            this.txtMDM.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMDM.Location = new System.Drawing.Point(142, 29);
            this.txtMDM.Name = "txtMDM";
            this.txtMDM.Size = new System.Drawing.Size(222, 26);
            this.txtMDM.TabIndex = 2;
            // 
            // lblTDM
            // 
            this.lblTDM.AutoSize = true;
            this.lblTDM.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTDM.Location = new System.Drawing.Point(38, 71);
            this.lblTDM.Name = "lblTDM";
            this.lblTDM.Size = new System.Drawing.Size(100, 19);
            this.lblTDM.TabIndex = 1;
            this.lblTDM.Text = "Tên Danh Mục";
            // 
            // lblMDM
            // 
            this.lblMDM.AutoSize = true;
            this.lblMDM.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMDM.Location = new System.Drawing.Point(38, 36);
            this.lblMDM.Name = "lblMDM";
            this.lblMDM.Size = new System.Drawing.Size(98, 19);
            this.lblMDM.TabIndex = 0;
            this.lblMDM.Text = "Mã Danh Mục";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(55, 214);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 30);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(178, 214);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(93, 30);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(300, 214);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(93, 30);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load Data";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(422, 214);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(93, 30);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // group_DM
            // 
            this.group_DM.Controls.Add(this.listView1);
            this.group_DM.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_DM.Location = new System.Drawing.Point(57, 267);
            this.group_DM.Name = "group_DM";
            this.group_DM.Size = new System.Drawing.Size(571, 171);
            this.group_DM.TabIndex = 6;
            this.group_DM.TabStop = false;
            this.group_DM.Text = "Thông Tin Danh Mục";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(30, 31);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(519, 126);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;  // Set the view to show details
            this.listView1.Columns.Add("Mã Danh Mục", 150, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Tên Danh Mục", 250, HorizontalAlignment.Left);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 450);
            this.Controls.Add(this.group_DM);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gb_danhmuc);
            this.Controls.Add(this.lblQTV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.gb_danhmuc.ResumeLayout(false);
            this.gb_danhmuc.PerformLayout();
            this.group_DM.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion

        private System.Windows.Forms.Label lblQTV;
        private System.Windows.Forms.GroupBox gb_danhmuc;
        private System.Windows.Forms.TextBox txtTDM;
        private System.Windows.Forms.TextBox txtMDM;
        private System.Windows.Forms.Label lblTDM;
        private System.Windows.Forms.Label lblMDM;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox group_DM;
        private System.Windows.Forms.ListView listView1;
    }
}
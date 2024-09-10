namespace QLLN
{
    partial class loginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_title = new Label();
            lblUser = new Label();
            lblPass = new Label();
            txtUser = new TextBox();
            txtPass = new TextBox();
            btnLogin = new Button();
            btnClear = new Button();
            SuspendLayout();
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.Font = new Font("Seven Swordsmen BB", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_title.ForeColor = SystemColors.Highlight;
            lbl_title.Location = new Point(70, 25);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(160, 23);
            lbl_title.TabIndex = 0;
            lbl_title.Text = "Hello Wolrd";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUser.Location = new Point(27, 75);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(73, 19);
            lblUser.TabIndex = 1;
            lblUser.Text = "Tài Khoản";
            lblUser.Click += lblUser_Click;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPass.Location = new Point(29, 108);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(71, 19);
            lblPass.TabIndex = 2;
            lblPass.Text = "Mật Khẩu";
            // 
            // txtUser
            // 
            txtUser.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUser.Location = new Point(119, 68);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(183, 26);
            txtUser.TabIndex = 3;
            // 
            // txtPass
            // 
            txtPass.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPass.Location = new Point(119, 100);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(183, 26);
            txtPass.TabIndex = 4;
            txtPass.TextChanged += textBox1_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(119, 144);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(96, 29);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Đăng Nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(221, 144);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(81, 29);
            btnClear.TabIndex = 6;
            btnClear.Text = "Xóa";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // loginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 189);
            Controls.Add(btnClear);
            Controls.Add(btnLogin);
            Controls.Add(txtPass);
            Controls.Add(txtUser);
            Controls.Add(lblPass);
            Controls.Add(lblUser);
            Controls.Add(lbl_title);
            Name = "loginForm";
            Text = "Quản Lý lẩu Nướng";
            Load += loginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_title;
        private Label lblUser;
        private Label lblPass;
        private TextBox txtUser;
        private TextBox txtPass;
        private Button btnLogin;
        private Button btnClear;
    }
}
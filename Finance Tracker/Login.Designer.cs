namespace Finance_Tracker
{
    partial class Login
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
            Text = new System.Windows.Forms.Label();
            password = new System.Windows.Forms.TextBox();
            repeatedPassword = new System.Windows.Forms.TextBox();
            Text2 = new System.Windows.Forms.Label();
            checkPassword = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // Text
            // 
            Text.AutoSize = true;
            Text.Location = new System.Drawing.Point(77, 9);
            Text.Name = "Text";
            Text.Size = new System.Drawing.Size(87, 15);
            Text.TabIndex = 0;
            Text.Text = "Enter password";
            // 
            // password
            // 
            password.Location = new System.Drawing.Point(12, 28);
            password.Name = "password";
            password.Size = new System.Drawing.Size(228, 23);
            password.TabIndex = 1;
            // 
            // repeatedPassword
            // 
            repeatedPassword.Location = new System.Drawing.Point(12, 79);
            repeatedPassword.Name = "repeatedPassword";
            repeatedPassword.Size = new System.Drawing.Size(228, 23);
            repeatedPassword.TabIndex = 2;
            // 
            // Text2
            // 
            Text2.AutoSize = true;
            Text2.Location = new System.Drawing.Point(77, 61);
            Text2.Name = "Text2";
            Text2.Size = new System.Drawing.Size(96, 15);
            Text2.TabIndex = 3;
            Text2.Text = "Repeat password";
            // 
            // checkPassword
            // 
            checkPassword.Location = new System.Drawing.Point(83, 108);
            checkPassword.Name = "checkPassword";
            checkPassword.Size = new System.Drawing.Size(75, 23);
            checkPassword.TabIndex = 4;
            checkPassword.Text = "Check";
            checkPassword.UseVisualStyleBackColor = true;
            checkPassword.Click += checkPassword_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(252, 138);
            Controls.Add(checkPassword);
            Controls.Add(Text2);
            Controls.Add(repeatedPassword);
            Controls.Add(password);
            Controls.Add(Text);
            Name = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label Text;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox repeatedPassword;
        private System.Windows.Forms.Label Text2;
        private System.Windows.Forms.Button checkPassword;
    }
}
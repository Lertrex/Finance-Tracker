namespace Finance_Tracker
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            pictureBox1 = new System.Windows.Forms.PictureBox();
            Title = new System.Windows.Forms.Label();
            CurrenciesBox = new System.Windows.Forms.ComboBox();
            transactions = new System.Windows.Forms.Button();
            accounts = new System.Windows.Forms.Button();
            changeTheme = new System.Windows.Forms.Button();
            AccountBox = new System.Windows.Forms.ComboBox();
            changePassword = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(14, 14);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(75, 74);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            Title.Location = new System.Drawing.Point(96, 25);
            Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Title.Name = "Title";
            Title.Size = new System.Drawing.Size(289, 42);
            Title.TabIndex = 1;
            Title.Text = "Finance Tracker";
            // 
            // CurrenciesBox
            // 
            CurrenciesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CurrenciesBox.FormattingEnabled = true;
            CurrenciesBox.Items.AddRange(new object[] { "Доллар", "Евро", "Рубль" });
            CurrenciesBox.Location = new System.Drawing.Point(780, 45);
            CurrenciesBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CurrenciesBox.Name = "CurrenciesBox";
            CurrenciesBox.Size = new System.Drawing.Size(140, 23);
            CurrenciesBox.TabIndex = 2;
            CurrenciesBox.SelectedIndexChanged += CurrenciesBox_SelectedIndexChanged;
            // 
            // transactions
            // 
            transactions.Location = new System.Drawing.Point(696, 12);
            transactions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            transactions.Name = "transactions";
            transactions.Size = new System.Drawing.Size(96, 27);
            transactions.TabIndex = 3;
            transactions.Text = "Transactions";
            transactions.UseVisualStyleBackColor = true;
            transactions.Click += transactions_Click;
            // 
            // accounts
            // 
            accounts.Location = new System.Drawing.Point(800, 12);
            accounts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            accounts.Name = "accounts";
            accounts.Size = new System.Drawing.Size(88, 25);
            accounts.TabIndex = 4;
            accounts.Text = "Accounts";
            accounts.UseVisualStyleBackColor = true;
            accounts.Click += accounts_Click;
            // 
            // changeTheme
            // 
            changeTheme.Location = new System.Drawing.Point(896, 12);
            changeTheme.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            changeTheme.Name = "changeTheme";
            changeTheme.Size = new System.Drawing.Size(24, 25);
            changeTheme.TabIndex = 5;
            changeTheme.UseVisualStyleBackColor = true;
            changeTheme.Click += changeTheme_Click;
            // 
            // AccountBox
            // 
            AccountBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            AccountBox.FormattingEnabled = true;
            AccountBox.Location = new System.Drawing.Point(652, 45);
            AccountBox.Name = "AccountBox";
            AccountBox.Size = new System.Drawing.Size(121, 23);
            AccountBox.TabIndex = 7;
            AccountBox.SelectedIndexChanged += AccountBox_SelectedIndexChanged;
            // 
            // changePassword
            // 
            changePassword.Location = new System.Drawing.Point(575, 12);
            changePassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            changePassword.Name = "changePassword";
            changePassword.Size = new System.Drawing.Size(113, 27);
            changePassword.TabIndex = 8;
            changePassword.Text = "Change password";
            changePassword.UseVisualStyleBackColor = true;
            changePassword.Click += changePassword_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(933, 519);
            Controls.Add(changePassword);
            Controls.Add(AccountBox);
            Controls.Add(changeTheme);
            Controls.Add(accounts);
            Controls.Add(transactions);
            Controls.Add(CurrenciesBox);
            Controls.Add(Title);
            Controls.Add(pictureBox1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MainWindow";
            Text = "Main Window";
            FormClosing += MainWindow_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.ComboBox CurrenciesBox;
        private System.Windows.Forms.Button transactions;
        private System.Windows.Forms.Button accounts;
        private System.Windows.Forms.Button changeTheme;
        private System.Windows.Forms.ComboBox AccountBox;
        private System.Windows.Forms.Button changePassword;
    }
}


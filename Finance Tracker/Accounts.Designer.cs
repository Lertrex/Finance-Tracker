namespace Finance_Tracker
{
    partial class Accounts
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
            accountsDataGrid = new System.Windows.Forms.DataGridView();
            Back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)accountsDataGrid).BeginInit();
            SuspendLayout();
            // 
            // accountsDataGrid
            // 
            accountsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            accountsDataGrid.Location = new System.Drawing.Point(12, 40);
            accountsDataGrid.Name = "accountsDataGrid";
            accountsDataGrid.Size = new System.Drawing.Size(776, 398);
            accountsDataGrid.TabIndex = 0;
            accountsDataGrid.CellValueChanged += accountsDataGrid_CellValueChanged;
            accountsDataGrid.UserAddedRow += accountsDataGrid_UserAddedRow;
            accountsDataGrid.UserDeletingRow += accountsDataGrid_UserDeletingRow;
            // 
            // Back
            // 
            Back.Location = new System.Drawing.Point(12, 11);
            Back.Name = "Back";
            Back.Size = new System.Drawing.Size(75, 23);
            Back.TabIndex = 1;
            Back.Text = "Back";
            Back.UseVisualStyleBackColor = true;
            Back.Click += Back_Click;
            // 
            // Accounts
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(Back);
            Controls.Add(accountsDataGrid);
            Name = "Accounts";
            Text = "Accounts";
            FormClosing += Accounts_FormClosing;
            ((System.ComponentModel.ISupportInitialize)accountsDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView accountsDataGrid;
        private System.Windows.Forms.Button Back;
    }
}
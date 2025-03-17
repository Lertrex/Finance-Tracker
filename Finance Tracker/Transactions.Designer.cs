namespace Finance_Tracker
{
    partial class Transactions
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
            transactionDataGrid = new System.Windows.Forms.DataGridView();
            AccountsList = new System.Windows.Forms.ComboBox();
            back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)transactionDataGrid).BeginInit();
            SuspendLayout();
            // 
            // transactionDataGrid
            // 
            transactionDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            transactionDataGrid.Location = new System.Drawing.Point(12, 38);
            transactionDataGrid.Name = "transactionDataGrid";
            transactionDataGrid.Size = new System.Drawing.Size(776, 400);
            transactionDataGrid.TabIndex = 0;
            transactionDataGrid.CellValueChanged += transactionDataGrid_CellValueChanged;
            transactionDataGrid.UserAddedRow += transactionDataGrid_UserAddedRow;
            transactionDataGrid.UserDeletingRow += transactionDataGrid_UserDeletingRow;
            // 
            // AccountsList
            // 
            AccountsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            AccountsList.FormattingEnabled = true;
            AccountsList.Location = new System.Drawing.Point(667, 9);
            AccountsList.Name = "AccountsList";
            AccountsList.Size = new System.Drawing.Size(121, 23);
            AccountsList.TabIndex = 1;
            AccountsList.SelectedIndexChanged += AccountsList_SelectedIndexChanged;
            // 
            // back
            // 
            back.Location = new System.Drawing.Point(12, 8);
            back.Name = "back";
            back.Size = new System.Drawing.Size(75, 23);
            back.TabIndex = 2;
            back.Text = "Back";
            back.UseVisualStyleBackColor = true;
            back.Click += back_Click;
            // 
            // Transactions
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(back);
            Controls.Add(AccountsList);
            Controls.Add(transactionDataGrid);
            Name = "Transactions";
            Text = "Transactions";
            FormClosing += Transactions_FormClosing;
            ((System.ComponentModel.ISupportInitialize)transactionDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView transactionDataGrid;
        private System.Windows.Forms.ComboBox AccountsList;
        private System.Windows.Forms.Button back;
    }
}
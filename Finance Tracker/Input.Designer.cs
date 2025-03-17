namespace Finance_Tracker
{
    partial class Input
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
            InputLabel = new System.Windows.Forms.Label();
            InputText = new System.Windows.Forms.TextBox();
            cancel = new System.Windows.Forms.Button();
            ok = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // InputLabel
            // 
            InputLabel.Location = new System.Drawing.Point(12, 9);
            InputLabel.Name = "InputLabel";
            InputLabel.Size = new System.Drawing.Size(200, 29);
            InputLabel.TabIndex = 0;
            // 
            // InputText
            // 
            InputText.Location = new System.Drawing.Point(12, 41);
            InputText.Name = "InputText";
            InputText.Size = new System.Drawing.Size(200, 23);
            InputText.TabIndex = 1;
            // 
            // cancel
            // 
            cancel.Location = new System.Drawing.Point(12, 70);
            cancel.Name = "cancel";
            cancel.Size = new System.Drawing.Size(75, 23);
            cancel.TabIndex = 2;
            cancel.Text = "Cancel";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += cancel_Click;
            // 
            // ok
            // 
            ok.Location = new System.Drawing.Point(137, 70);
            ok.Name = "ok";
            ok.Size = new System.Drawing.Size(75, 23);
            ok.TabIndex = 3;
            ok.Text = "OK";
            ok.UseVisualStyleBackColor = true;
            ok.Click += ok_Click;
            // 
            // Input
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(224, 105);
            Controls.Add(ok);
            Controls.Add(cancel);
            Controls.Add(InputText);
            Controls.Add(InputLabel);
            Name = "Input";
            Text = "Input";
            FormClosing += Input_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.TextBox InputText;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
    }
}
using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Forms;

namespace Finance_Tracker
{
    public partial class Input : Form
    {
        private ThemeManager.Theme currentTheme = ThemeManager.Theme.Light;
        private void ApplyCurrentTheme() { ThemeManager.ApplyTheme(this, currentTheme); }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TextInput { get; private set; }
        public Input(string label)
        {
            InitializeComponent();
            if (ConfigurationManager.AppSettings.Get("theme") == "light") { currentTheme = ThemeManager.Theme.Light; }
            else { currentTheme = ThemeManager.Theme.Dark; }
            ApplyCurrentTheme();
            InputLabel.Text = label;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(InputText.Text))
            {
                TextInput = InputText.Text;
                Close();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Enter Text");
            }
        }

        private void Input_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

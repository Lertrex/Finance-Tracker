using System;
using System.Windows.Forms;
using System.Configuration;

namespace Finance_Tracker
{
    public partial class Login : Form
    {
        private ThemeManager.Theme currentTheme = ThemeManager.Theme.Light;
        private void ApplyCurrentTheme() { ThemeManager.ApplyTheme(this, currentTheme); }
        public Login()
        {
            InitializeComponent();
            if (ConfigurationManager.AppSettings.Get("theme") == "light") { currentTheme = ThemeManager.Theme.Light; }
            else { currentTheme = ThemeManager.Theme.Dark; }
            ApplyCurrentTheme();
            if (ConfigurationManager.AppSettings.Get("password") != "")
            {
                Text2.Dispose();
                repeatedPassword.Dispose();
            }
        }

        private void checkPassword_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings.Get("password") == "")
            {
                if (repeatedPassword.Text == password.Text)
                {
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password.Text, BCrypt.Net.BCrypt.GenerateSalt());
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    AppSettingsSection asSection = config.AppSettings;
                    asSection.Settings.Remove("password");
                    asSection.Settings.Add("password", hashedPassword);
                    config.Save();
                    Hide();
                    MainWindow Main = new MainWindow();
                    Main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Passwords don't match");
                }
            }
            else
            {
                if (BCrypt.Net.BCrypt.Verify(password.Text, ConfigurationManager.AppSettings.Get("password")))
                {
                    Hide();
                    MainWindow Main = new MainWindow();
                    Main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid password");
                }
            }
        }
    }
}

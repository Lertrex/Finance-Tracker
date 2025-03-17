using Finance_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

namespace Finance_Tracker
{
    public partial class Accounts : Form
    {
        List<Account> accounts;
        private AppDbContext _context = new AppDbContext();
        private ThemeManager.Theme currentTheme = ThemeManager.Theme.Light;
        private void ApplyCurrentTheme() { ThemeManager.ApplyTheme(this, currentTheme); }
        public Accounts(List<Account> Accounts, string Account)
        {
            InitializeComponent();
            if (ConfigurationManager.AppSettings.Get("theme") == "light") { currentTheme = ThemeManager.Theme.Light; }
            else { currentTheme = ThemeManager.Theme.Dark; }
            ApplyCurrentTheme();
            accountsDataGrid.Columns.Add("Id", "Id");
            accountsDataGrid.Columns.Add("BankName", "BankName");
            accountsDataGrid.Columns.Add("Name", "Name");
            accountsDataGrid.Columns.Add("Money", "Money");
            accountsDataGrid.DataSource = null;
            using (AppDbContext db = new AppDbContext())
            {
                accounts = db.Accounts.ToList();
                foreach (Account account in accounts)
                {
                    accountsDataGrid.Rows.Add(account.Id, account.BankName, account.Name, account.Money);
                }
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Accounts_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void accountsDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = Convert.ToInt32(accountsDataGrid.Rows[e.RowIndex].Cells["Id"].Value);
                var account = _context.Accounts.FirstOrDefault(a => a.Id == id);
                string Column = accountsDataGrid.Columns[accountsDataGrid.CurrentCell.ColumnIndex].Name;
                object newValue = accountsDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                switch (Column)
                {
                    case "BankName":
                        account.BankName = newValue.ToString();
                        break;
                    case "Name":
                        account.Name = newValue.ToString();
                        break;
                    case "Money":
                        account.Money = Convert.ToDecimal(newValue);
                        break;
                    default:
                        return;
                }
                _context.SaveChanges();
            }
        }

        private void accountsDataGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.Cells["Id"].Value != null && e.Row.Cells["BankName"].Value != null &&
                e.Row.Cells["Name"].Value != null && e.Row.Cells["Money"].Value != null)
            {
                int Id = Convert.ToInt32(e.Row.Cells["Id"].Value);
                string BankName = e.Row.Cells["BankName"].Value.ToString();
                string Name = e.Row.Cells["Name"].Value.ToString();
                decimal Money = Convert.ToDecimal(e.Row.Cells["Money"].Value);
                var newAccount = new Account
                {
                    Id = Id,
                    BankName = BankName,
                    Name = Name,
                    Money = Money
                };

                _context.Accounts.Add(newAccount);
                _context.SaveChanges();
                accountsDataGrid.Rows.Add(newAccount);
            }
        }

        private void accountsDataGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = Convert.ToInt32(e.Row.Cells["Id"].Value);
            var account = _context.Accounts.FirstOrDefault(a => a.Id == id);
            _context.Accounts.Remove(account);
            _context.SaveChanges();
        }
    }
}

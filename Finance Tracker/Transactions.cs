using Finance_Tracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Finance_Tracker
{
    public partial class Transactions : Form
    {
        List<Transaction> transactions;
        private AppDbContext _context = new AppDbContext();
        List<Account> Accounts;
        private int id;
        private ThemeManager.Theme currentTheme = ThemeManager.Theme.Light;
        private void ApplyCurrentTheme() { ThemeManager.ApplyTheme(this, currentTheme); }
        public Transactions(List<Account> Accounts, string Account)
        {
            InitializeComponent();
            if (ConfigurationManager.AppSettings.Get("theme") == "light") { currentTheme = ThemeManager.Theme.Light; }
            else { currentTheme = ThemeManager.Theme.Dark; }
            ApplyCurrentTheme();
            transactionDataGrid.DataSource = null;
            transactionDataGrid.Columns.Add("Id", "Id");
            transactionDataGrid.Columns.Add("Date", "Date");
            transactionDataGrid.Columns.Add("Category", "Category");
            transactionDataGrid.Columns.Add("Payee", "Payee");
            transactionDataGrid.Columns.Add("Amount", "Amount");
            transactionDataGrid.Columns.Add("Account", "Account");
            this.Accounts = Accounts;
            foreach (var account in Accounts)
            {
                AccountsList.Items.Add(account.Name);
            }
            foreach (var account in Accounts)
            {
                if (account.Name == Account)
                {
                    id = account.Id;
                }
            }
            AccountsList.Items.Add("All");
            using (AppDbContext db = new AppDbContext())
            {
                transactions = db.Transactions.ToList();
                foreach (Transaction transaction in transactions)
                {
                    if (transaction.Account == id)
                    { 
                        transactionDataGrid.Rows.Add(transaction.Id, transaction.Date, transaction.Category, 
                            transaction.Payee, transaction.Amount, transaction.Account);
                    }
                }
            }
            AccountsList.SelectedIndex = id;
        }

        private void AccountsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            transactionDataGrid.Rows.Clear();
            if (AccountsList.SelectedItem == "All")
            {
                using (AppDbContext db = new AppDbContext())
                {
                    foreach (Transaction transaction in transactions)
                    {
                        transactionDataGrid.Rows.Add(transaction.Id, transaction.Date, transaction.Category,
                            transaction.Payee, transaction.Amount, transaction.Account);
                    }
                }
            }
            else
            {
                int id = AccountsList.SelectedIndex;
                using (AppDbContext db = new AppDbContext())
                {
                    foreach (Transaction transaction in transactions)
                    {
                        if (transaction.Account == id)
                        {
                            transactionDataGrid.Rows.Add(transaction.Id, transaction.Date, transaction.Category,
                            transaction.Payee, transaction.Amount, transaction.Account);
                        }
                    }
                }
            }
        }

        private void transactionDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                foreach(var value in transactions.GetType().GetFields())
                {
                    if (string.IsNullOrEmpty(value.ToString()))
                    {
                        return;
                    }
                }
                int id = Convert.ToInt32(transactionDataGrid.Rows[e.RowIndex].Cells["Id"].Value);
                var transaction = _context.Transactions.FirstOrDefault(a => a.Id == id);
                string Column = transactionDataGrid.Columns[transactionDataGrid.CurrentCell.ColumnIndex].Name;
                object newValue = transactionDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                switch (Column)
                {
                    case "Date":
                        transaction.Date = Convert.ToDateTime(newValue);
                        break;
                    case "Category":
                        transaction.Category = newValue.ToString();
                        break;
                    case "Payee":
                        transaction.Payee = newValue.ToString();
                        break;
                    case "Amount":
                        transaction.Amount = Convert.ToInt32(newValue);
                        break;
                    case "Account":
                        transaction.Account = Convert.ToInt32(newValue);
                        break;
                    default:
                        return;
                }
                _context.SaveChanges();
            }
        }

        private void transactionDataGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.Cells["Id"].Value != null && e.Row.Cells["Date"].Value != null &&
                e.Row.Cells["Category"].Value != null && e.Row.Cells["Payee"].Value != null
                && e.Row.Cells["Amount"].Value != null && e.Row.Cells["Account"].Value != null)
            {
                int Id = Convert.ToInt32(e.Row.Cells["Id"].Value);
                DateTime Date = Convert.ToDateTime(e.Row.Cells["Date"].Value);
                string Category = e.Row.Cells["Category"].Value.ToString();
                string Payee = e.Row.Cells["Payee"].Value.ToString();
                int Amount = Convert.ToInt32(e.Row.Cells["Amount"].Value);
                int Account = Convert.ToInt32(e.Row.Cells["Account"].Value);
                var newTransaction = new Transaction
                {
                    Id = Id,
                    Date = Date,
                    Category = Category,
                    Payee = Payee,
                    Amount = Amount,
                    Account = Account
                };

                _context.Transactions.Add(newTransaction);
                _context.SaveChanges();
                transactionDataGrid.Rows.Add(newTransaction);
            }
        }

        private void transactionDataGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = Convert.ToInt32(e.Row.Cells["Id"].Value);
            var transaction = _context.Transactions.FirstOrDefault(a => a.Id == id);
            _context.Transactions.Remove(transaction);
            _context.SaveChanges();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Transactions_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}

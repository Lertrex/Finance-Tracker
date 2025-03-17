using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Net;
using Finance_Tracker.Models;
using Microsoft.IdentityModel.Tokens;

namespace Finance_Tracker
{
    public partial class MainWindow : Form
    {
        static float[] course = { float.Parse(GetRate("USD")), float.Parse(GetRate("EUR")), 1F };
        static string[,] Currencies = { { "USD", "EUR", "RUB" }, { "$", "€", "₽" } };
        private string account;
        private int accountId;
        private List<string> categoriesWaste = new List<string>();
        private List<string> categoriesIncome = new List<string>();
        private List<Account> Accounts;
        private Dictionary<string, decimal> Wastes = new Dictionary<string, decimal>();
        private Dictionary<string, decimal> Income = new Dictionary<string, decimal>();
        private float[] wasteValues = { 0F };
        private float[] incomeValues = { 0F };
        private static int hoveredIndex = -1;
        int currency;
        CircularChart wastes;
        CircularChart income;
        public static string[] Banks = { "" };
        private static ThemeManager.Theme currentTheme = ThemeManager.Theme.Light;
        private void ApplyCurrentTheme() { ThemeManager.ApplyTheme(this, currentTheme); }
        public class CircularChart : Control
        {
            private string[] labels = { "" };
            private Color[] colors = { Color.SeaGreen, Color.Orange, Color.Blue };
            private int legendWidth = 250;
            private float rate;
            private string valute;
            private string currencyText;
            private bool noData = false;
            private decimal totalAmount = 0;
            public CircularChart()
            {
                DoubleBuffered = true;
            }
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public int Currency
            {
                get;
                set
                {
                    field = value; UpdateCurrencyText(value);
                    Invalidate();
                }
            }
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public bool NoData
            {
                get => noData;
                set { noData = value; Invalidate(); }
            }
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public float[] Values
            {
                get;
                set { field = value; Invalidate(); }
            }
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public string[] Labels
            {
                get => labels;
                set { labels = value; Invalidate(); }
            }
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public Color[] Colors
            {
                get => colors;
                set { colors = value; Invalidate(); }
            }
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public decimal TotalAmount
            {
                get => totalAmount;
                set { totalAmount = value; UpdateCurrencyText(Currency); Invalidate(); }
            }
            private void UpdateCurrencyText(int currency)
            {
                int currencyIndex = GetCurrencyIndex(currency);
                rate = course[currencyIndex];
                valute = Currencies[1, this.Currency];
                currencyText = $"{(int)(TotalAmount / (decimal)rate)} {Currencies[1, this.Currency]}";
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int chartSize = 200;
                int centerX = Width / 2;
                int centerY = 20;
                Rectangle rect = new Rectangle(centerX - chartSize / 2, centerY, chartSize, chartSize);

                if (NoData)
                {
                    using (System.Drawing.Font font = new System.Drawing.Font("Arial", 12, FontStyle.Bold))
                    using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    {
                        if (currentTheme == ThemeManager.Theme.Light)
                        {
                            g.DrawString("Недостаточно данных", font, Brushes.Black, new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2), sf);
                        }
                        else
                        {
                            g.DrawString("Недостаточно данных", font, Brushes.White, new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2), sf);
                        }
                    }
                    return;
                }


                float total = Values.Sum() / rate;
                float startAngle = -90f;

                for (int i = 0; i < Values.Length; i++)
                {
                    float sweepAngle = (Values[i] / Values.Sum()) * 360f;
                    float thickness = (i == hoveredIndex) ? 15f : 10f;

                    using (Pen pen = new Pen(Colors[i % Colors.Length], thickness))
                    {
                        g.DrawArc(pen, rect, startAngle, sweepAngle);
                    }

                    if (i == hoveredIndex)
                    {
                        DrawCategoryLabel(g, rect, startAngle + sweepAngle / 2, Labels[i], Values[i] / rate);
                    }

                    startAngle += sweepAngle;
                }

                if (hoveredIndex == -1)
                {
                    DrawCenterText(g, rect, currencyText);
                }

                if (!DesignMode)
                    DrawLegend(g, centerX, rect.Bottom + 20);
            }
            private void DrawCenterText(Graphics g, Rectangle rect, string text)
            {
                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 12, FontStyle.Bold))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    if (currentTheme == ThemeManager.Theme.Light)
                    {
                        g.DrawString(text, font, Brushes.Black, new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2), sf);
                    }
                    else
                    {
                        g.DrawString(text, font, Brushes.White, new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2), sf);
                    }
                }
            }
            private void DrawCategoryLabel(Graphics g, Rectangle rect, float angle, string label, float value)
            {
                double radians = (angle - 90) * Math.PI / 180;
                int labelX = rect.X + rect.Width / 2 + (int)(Math.Cos(radians) * rect.Width / 2.5);
                int labelY = rect.Y + rect.Height / 2 + (int)(Math.Sin(radians) * rect.Height / 2.5);

                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 12, FontStyle.Bold))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    if (currentTheme == ThemeManager.Theme.Light)
                    {
                        g.DrawString($"{value:0.##} {valute}", font, Brushes.Black, new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2 - 10), sf);
                        g.DrawString(label, font, Brushes.Black, new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2 + 10), sf);
                    }
                    else
                    {
                        g.DrawString($"{value:0.##} {valute}", font, Brushes.White, new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2 - 10), sf);
                        g.DrawString(label, font, Brushes.White, new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2 + 10), sf);
                    }
                }
            }
            private void DrawLegend(Graphics g, int centerX, int startY)
            {
                if (Labels.IsNullOrEmpty() || Labels.Length <= 1 && Labels[0] == "") return;

                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 10))
                {
                    int rowHeight = (int)g.MeasureString("A", font).Height + 10;
                    int x = Convert.ToInt32(centerX - legendWidth / 2.5), y = startY;

                    for (int i = 0; i < labels.Length; i++)
                    {
                        int textWidth = (int)g.MeasureString(labels[i], font).Width + 25;

                        if (x + textWidth > centerX + legendWidth / 2)
                        {
                            x = Convert.ToInt32(centerX - legendWidth / 2.5);
                            y += rowHeight;
                        }

                        Brush brush = new SolidBrush(colors[i % colors.Length]);
                        g.FillEllipse(brush, x, y + 5, 10, 10);
                        if (currentTheme == ThemeManager.Theme.Light)
                        {
                            g.DrawString(labels[i], font, Brushes.Black, x + 15, y);
                        }
                        else
                        {
                            g.DrawString(labels[i], font, Brushes.White, x + 15, y);
                        }
                        x += textWidth;
                    }
                }
            }
            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);
                int newHoveredIndex = GetHoveredSegmentIndex(e.Location);

                if (newHoveredIndex != hoveredIndex)
                {
                    hoveredIndex = newHoveredIndex;
                    Invalidate();
                }
            }
            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                hoveredIndex = -1;
                Invalidate();
            }
            private int GetHoveredSegmentIndex(Point mousePos)
            {
                float total = Values.Sum();
                float startAngle = -90f;
                int centerX = Width / 2;
                int centerY = 20 + 100;
                int radius = 100;

                double dx = mousePos.X - centerX;
                double dy = mousePos.Y - centerY;
                double distance = Math.Sqrt(dx * dx + dy * dy);

                if (distance < radius - 20 || distance > radius + 10)
                    return -1;

                double angle = Math.Atan2(dy, dx) * 180 / Math.PI;
                if (angle < -90) angle += 360;

                for (int i = 0; i < Values.Length; i++)
                {
                    float sweepAngle = (Values[i] / total) * 360f;
                    if (angle >= startAngle && angle <= startAngle + sweepAngle)
                    {
                        return i;
                    }
                    startAngle += sweepAngle;
                }
                return -1;
            }
        }
        private static int GetCurrencyIndex(int currencyIndex)
        {
            if (currencyIndex >= 0 && currencyIndex < Currencies.GetLength(1))
            {
                return currencyIndex;
            }
            else
            {
                return -1;
            }
        }
        private static String GetRate(string Valute)
        {
            if (Valute == "RUB") { return "1"; }
            string url = "http://www.cbr.ru/scripts/XML_daily.asp";

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.GetEncoding("windows-1251");
                string xmlData = client.DownloadString(url);

                DataSet ds = new DataSet();
                using (System.IO.StringReader reader = new System.IO.StringReader(xmlData))
                {
                    ds.ReadXml(reader);
                }
                DataTable currency = ds.Tables["Valute"];
                foreach (DataRow row in currency.Rows)
                {
                    if (row["CharCode"].ToString() == Valute)
                    {
                        return row["Value"].ToString();
                    }
                }
            }

            return "1";

        }
        public MainWindow()
        {
            if (ConfigurationManager.AppSettings.Get("currency") != "")
            {
                currency = Convert.ToInt16(ConfigurationManager.AppSettings.Get("currency"));
            }
            else
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection asSection = config.AppSettings;
                asSection.Settings.Remove("currency");
                asSection.Settings.Add("currency", "0");
                config.Save();
                ConfigurationManager.RefreshSection(asSection.SectionInformation.Name);
            }
            this.Text = "Finance Tracker";
            this.Size = new Size(400, 450);
            using (AppDbContext db = new AppDbContext())
            {
                Accounts = db.Accounts.ToList();
                foreach (Account acc in Accounts)
                {
                    if (acc.IsChoose == 1)
                    {
                        account = acc.Name;
                        accountId = acc.Id;
                    }
                }
            }
            LoadData("All");

            wastes = new CircularChart
            {
                Values = wasteValues.ToArray(),
                Labels = categoriesWaste.ToArray(),
                Colors = new Color[] { Color.Green, Color.Red, Color.Blue, Color.Purple, Color.Orange },
                Location = new Point(0, 100),
                Currency = currency,
                Size = new Size(400, 400),
                NoData = (categoriesWaste.Count == 0),
                TotalAmount = (decimal)wasteValues.Sum()
            };
            income = new CircularChart
            {
                Values = incomeValues.ToArray(),
                Labels = categoriesIncome.ToArray(),
                Colors = new Color[] { Color.Green, Color.Red, Color.Blue, Color.Purple, Color.Orange },
                Location = new Point(500, 100),
                Currency = currency,
                Size = new Size(400, 400),
                NoData = (categoriesIncome.Count == 0),
                TotalAmount = (decimal)incomeValues.Sum()
            };

            Controls.Add(wastes);
            Controls.Add(income);
            InitializeComponent();
            if (ConfigurationManager.AppSettings.Get("theme") == "light") { currentTheme = ThemeManager.Theme.Light; changeTheme.Text = "🌒"; }
            else { currentTheme = ThemeManager.Theme.Dark; changeTheme.Text = "🔆"; }
            ApplyCurrentTheme();
            CurrenciesBox.SelectedIndex = 0;
            foreach (Account acc in Accounts)
            {
                AccountBox.Items.Add(acc.Name);
            }
            AccountBox.Items.Add("All");
            AccountBox.SelectedItem = "All";
            CurrenciesBox.SelectedIndex = currency;
        }
        private void CurrenciesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection asSection = config.AppSettings;
            asSection.Settings.Remove("currency");
            asSection.Settings.Add("currency", CurrenciesBox.SelectedIndex.ToString());
            config.Save();
            ConfigurationManager.RefreshSection(asSection.SectionInformation.Name);
            wastes.Currency = CurrenciesBox.SelectedIndex;
            wastes.Invalidate();
            income.Currency = CurrenciesBox.SelectedIndex;
            income.Invalidate();
        }
        private void transactions_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Transactions transactionsForm = new Transactions(Accounts, account);
            if (transactionsForm.ShowDialog() == DialogResult.OK)
            {
                this.Enabled = true;
                LoadData(AccountBox.SelectedItem.ToString());
                UpdateCharts();
            }
        }
        private void accounts_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Accounts accountsForm = new Accounts(Accounts, account);
            if (accountsForm.ShowDialog() == DialogResult.OK)
            {
                this.Enabled = true;
            }
        }
        private void AccountBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(AccountBox.SelectedItem.ToString());
            UpdateCharts();
        }
        private void LoadData(string selectedAccount)
        {
            categoriesWaste.Clear();
            categoriesIncome.Clear();
            Wastes.Clear();
            Income.Clear();

            using (AppDbContext db = new AppDbContext())
            {
                List<Transaction> transactions = db.Transactions.ToList();

                foreach (Transaction transaction in transactions)
                {
                    string categoryName = transaction.Category;
                    bool includeTransaction = (selectedAccount == "All") ||
                                             (Accounts.Any(acc => acc.Name == selectedAccount && acc.Id == transaction.Account));

                    if (includeTransaction)
                    {
                        if (transaction.Amount < 0)
                        {
                            if (!categoriesWaste.Contains(categoryName))
                            {
                                categoriesWaste.Add(categoryName);
                            }
                            if (Wastes.ContainsKey(categoryName))
                            {
                                Wastes[categoryName] += transaction.Amount;
                            }
                            else
                            {
                                Wastes[categoryName] = transaction.Amount;
                            }
                        }
                        else
                        {
                            if (!categoriesIncome.Contains(categoryName))
                            {
                                categoriesIncome.Add(categoryName);
                            }
                            if (Income.ContainsKey(categoryName))
                            {
                                Income[categoryName] += transaction.Amount;
                            }
                            else
                            {
                                Income[categoryName] = transaction.Amount;
                            }
                        }
                    }
                }
            }

            var sortedWasteCategories = categoriesWaste
                .OrderByDescending(c => Wastes.ContainsKey(c) ? Math.Abs(Wastes[c]) : 0)
                .ToList();

            var sortedIncomeCategories = categoriesIncome
                .OrderByDescending(c => Income.ContainsKey(c) ? Income[c] : 0)
                .ToList();

            categoriesWaste = sortedWasteCategories;
            categoriesIncome = sortedIncomeCategories;

            wasteValues = categoriesWaste.Select(c => Wastes.ContainsKey(c) ? (float)Math.Abs(Wastes[c]) : 0f).ToArray();
            incomeValues = categoriesIncome.Select(c => Income.ContainsKey(c) ? (float)Income[c] : 0f).ToArray();


        }
        private void UpdateCharts()
        {
            income.Values = incomeValues.ToArray();
            income.Labels = categoriesIncome.ToArray();
            income.NoData = (categoriesIncome.Count == 0);
            wastes.Values = wasteValues.ToArray();
            wastes.Labels = categoriesWaste.ToArray();
            wastes.NoData = (categoriesWaste.Count == 0);
            income.Invalidate();
            wastes.Invalidate();

            wastes.TotalAmount = (decimal)wasteValues.Sum();
            income.TotalAmount = (decimal)incomeValues.Sum();

        }
        private void changeTheme_Click(object sender, EventArgs e)
        {
            string theme;
            if (currentTheme == ThemeManager.Theme.Dark) { currentTheme = ThemeManager.Theme.Light; theme = "light"; changeTheme.Text = "🌒"; }
            else { currentTheme = ThemeManager.Theme.Dark; theme = "dark"; changeTheme.Text = "🔆"; }
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection asSection = config.AppSettings;
            asSection.Settings.Remove("theme");
            asSection.Settings.Add("theme", theme);
            config.Save();
            ApplyCurrentTheme();
        }
        private void changePassword_Click(object sender, EventArgs e)
        {
            Input InputForm = new Input("Enter password");
            if (InputForm.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(InputForm.TextInput))
                {
                    if (BCrypt.Net.BCrypt.Verify(InputForm.TextInput, ConfigurationManager.AppSettings.Get("password")))
                    {
                        InputForm.Close();
                        Input InputForm2 = new Input("Enter new password");
                        if (InputForm2.ShowDialog() == DialogResult.OK)
                        {
                            if (!string.IsNullOrWhiteSpace(InputForm2.TextInput))
                            {
                                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(InputForm2.TextInput, BCrypt.Net.BCrypt.GenerateSalt());
                                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                                AppSettingsSection asSection = config.AppSettings;
                                asSection.Settings.Remove("password");
                                asSection.Settings.Add("password", hashedPassword);
                                config.Save();
                                InputForm2.Close();
                                MessageBox.Show("New password saved");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password");
                        changePassword_Click(sender, e);
                    }
                }
                else
                {
                    changePassword_Click(sender, e);
                }
            }
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
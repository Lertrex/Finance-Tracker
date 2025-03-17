using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Finance_Tracker
{
    public static class ThemeManager
    {
        public enum Theme { Light, Dark }

        public static void ApplyTheme(Form form, Theme theme)
        {
            switch (theme)
            {
                case Theme.Light:
                    ApplyLightTheme(form);
                    break;
                case Theme.Dark:
                    ApplyDarkTheme(form);
                    break;
            }
        }

        private static void ApplyLightTheme(Form form)
        {
            form.BackColor = SystemColors.Control;
            form.ForeColor = SystemColors.ControlText;

            foreach (Control control in GetAllControls(form))
            {
                control.BackColor = SystemColors.Control;
                control.ForeColor = SystemColors.ControlText;

                if (control is TextBox)
                {
                    ((TextBox)control).BorderStyle = BorderStyle.Fixed3D;
                }
                else if (control is Button)
                {
                    ((Button)control).FlatStyle = FlatStyle.Standard;
                }
                else if (control is Label)
                {
                    ((Label)control).FlatStyle = FlatStyle.Standard;
                }
            }
        }

        private static void ApplyDarkTheme(Form form)
        {
            Color darkBackColor = Color.FromArgb(37, 37, 38);
            Color darkForeColor = Color.LightGray;

            form.BackColor = darkBackColor;
            form.ForeColor = darkForeColor;

            foreach (Control control in GetAllControls(form))
            {
                control.BackColor = darkBackColor;
                control.ForeColor = darkForeColor;

                if (control is ComboBox)
                {
                    ((ComboBox)control).ForeColor = darkForeColor;
                    ((ComboBox)control).BackColor = Color.FromArgb(60, 60, 60);
                }
                else if (control is Button)
                {
                    ((Button)control).FlatStyle = FlatStyle.Flat;
                    ((Button)control).FlatAppearance.BorderColor = Color.Gray;
                    ((Button)control).FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
                    ((Button)control).FlatAppearance.MouseDownBackColor = Color.FromArgb(90, 90, 90);
                }
                else if (control is DataGridView)
                {
                    ((DataGridView)control).EnableHeadersVisualStyles = false;
                    ((DataGridView)control).BackgroundColor = darkBackColor;
                    ((DataGridView)control).GridColor = Color.Gray;
                    ((DataGridView)control).ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
                    ((DataGridView)control).ColumnHeadersDefaultCellStyle.ForeColor = darkForeColor;
                    ((DataGridView)control).DefaultCellStyle.BackColor = darkBackColor;
                    ((DataGridView)control).DefaultCellStyle.ForeColor = darkForeColor;
                    ((DataGridView)control).RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);

                }
                else if (control is MenuStrip)
                {
                    ((MenuStrip)control).BackColor = Color.FromArgb(50, 50, 50);
                    ((MenuStrip)control).ForeColor = darkForeColor;
                }
                else if (control is ToolStripDropDownMenu)
                {
                    ((ToolStripDropDownMenu)control).BackColor = Color.FromArgb(50, 50, 50);
                    ((ToolStripDropDownMenu)control).ForeColor = darkForeColor;
                }
                else if (control is Label)
                {
                    ((Label)control).ForeColor = darkForeColor;
                }
            }
        }

        private static IEnumerable<Control> GetAllControls(Control container)
        {
            List<Control> controlList = new List<Control>();
            foreach (Control c in container.Controls)
            {
                controlList.Add(c);
                controlList.AddRange(GetAllControls(c));
            }
            return controlList;
        }
    }
}

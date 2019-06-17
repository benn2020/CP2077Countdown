using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Countdown
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Left = -300;
            this.Top = 835;
            //this.ShowDialog();
        }

        private void tmrCountdown_Tick(object sender, EventArgs e)
        {
            lblDate.Text = countdown();
        }

        private string countdown()
        {
            //Setting values
            DateTime daysLeft = DateTime.Parse("16/04/2020 00:00:01 AM");
            DateTime startDate = DateTime.Now;

            //Calculations
            TimeSpan t = daysLeft - startDate;
            string countdown = string.Format("{0} Days, {1} Hours, {2} Minutes, {3} Seconds til launch.", t.Days, t.Hours, t.Minutes, t.Seconds);

            return countdown;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }
    }
}

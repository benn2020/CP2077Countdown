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
        string countdownDate = "19/11/2020 00:00:01 AM";

        // Starts form in correct position
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Left = -300;
            this.Top = 925;
            //PlaceLowerRight();
        }

        //Places form in bottom right of screen
        private void PlaceLowerRight()
        {
            //Determine "rightmost" screen
            Screen rightmost = Screen.AllScreens[0];
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                    rightmost = screen;
            }

            this.Left = rightmost.WorkingArea.Right - this.Width;
            this.Top = rightmost.WorkingArea.Bottom - this.Height;
        }

        // Updates text every second
        private void tmrCountdown_Tick(object sender, EventArgs e)
        {
            lblDate.Text = countdown(countdownDate);
        }

        // Function for getting the time left 
        private string countdown(string countdownDate)
        {
            //Setting values
            DateTime daysLeft = DateTime.Parse(countdownDate);
            DateTime startDate = DateTime.Now;

            //Calculations
            TimeSpan t = daysLeft - startDate;
            string countdown = string.Format("{0} Days, {1} Hours, {2} Minutes, {3} Seconds til launch.", t.Days, t.Hours, t.Minutes, t.Seconds);

            return countdown;
        }

        // Code for when window is minimized
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        // Code to launch app from taskbar icon
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        // Stops app from properly closing from the window
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        // Menu for the notification icon to exit 
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Closes application
            Application.Exit();
        }
    }
}

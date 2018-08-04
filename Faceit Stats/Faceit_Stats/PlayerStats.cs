using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faceit_Stats
{
    public partial class PlayerStats : Form
    {
        string json;
        public Point mouseLoc;

        public PlayerStats(string jsonString)
        {
            InitializeComponent();
            json = jsonString;
        }

        private void PlayerStats_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLoc = new Point(-e.X, -e.Y);
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.faceit.com");
        }

        private void pnlTopBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = MousePosition;
                mousePos.Offset(mouseLoc.X, mouseLoc.Y);
                Location = mousePos;
            }
        }
    }
}

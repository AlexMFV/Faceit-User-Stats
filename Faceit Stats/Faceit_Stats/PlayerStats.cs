using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using PR = Faceit_Stats.Properties.Resources;

namespace Faceit_Stats
{
    public partial class PlayerStats : Form
    {
        #region Variaveis

        string Username;
        Point mouseLoc;     

        #endregion

        public PlayerStats(string nick)
        {
            this.Hide();
            Thread splashthread = new Thread(new ThreadStart(SplashScreen.ShowSplashScreen));
            splashthread.IsBackground = true;
            splashthread.Start();
            InitializeComponent();
            Username = nick;
        }

        private void PlayerStats_Load(object sender, EventArgs e)
        {
            LoadForm(Username);

            this.Show();
            SplashScreen.CloseSplashScreen();
            this.Activate();
        }

        public void LoadForm(string Username)
        {
            Player P = new Player(Username);

            btnPImage.Image = P.Avatar;
            btnFlag.Image = P.Flag;
            lblIGN.Text = P.InGameName;
            prgLevel.ProgressColor = PaintLevel(P.Skill_Level);
            prgLevel.Value = P.Skill_Level;
            lblPlayerLevel.ForeColor = PaintLevel(P.Skill_Level);
            lblPlayerLevel.Text = P.Skill_Level.ToString();
            btnRegion.Image = P.Flag;
            btnGlobalFlag.Image = P.GlobalFlag;
            lblPlayerELO.Text = P.InGameName.ToUpper() + "'S ELO IS " + P.ELO;
            prgElo.Value = (P.ELO > 2200 ? 2200 : P.ELO);

            if (P.Skill_Level != 10)
                lblNextLevel.Text = "To reach level " + (P.Skill_Level + 1)
                    + " you need " + EloCount(P.ELO, (P.Skill_Level + 1)) + " more points";
            else
                lblNextLevel.Text = "Congratulations! You're a beast!";

            if (P.Region != "")
            {
                lblCountryRank.Text = P.Country + ": " + P.CountryRank.ToString("#,#");
                lblRegionRank.Text = P.Region + ": " + P.RegionRank.ToString("#,#");
            }
            else
            {
                lblCountryRank.Text = "Unranked";
                lblRegionRank.Text = "Unranked";
            }
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

        public Color PaintLevel(int lvl)
        {
            switch (lvl)
            {
                case 2: return Color.FromArgb(34, 200, 6);
                case 3: return Color.FromArgb(34, 200, 6);
                case 4: return Color.FromArgb(255, 214, 0);
                case 5: return Color.FromArgb(255, 214, 0);
                case 6: return Color.FromArgb(255, 214, 0);
                case 7: return Color.FromArgb(255, 214, 0);
                case 8: return Color.FromArgb(242, 105, 29);
                case 9: return Color.FromArgb(242, 105, 29);
                case 10: return Color.FromArgb(209, 34, 34);
                default: return Color.White;
            }
        }

        public int EloCount(int Elo, int level)
        {
            switch(level)
            {
                case 3: return (950 - Elo);
                case 4: return (1100 - Elo);
                case 5: return (1250 - Elo);
                case 6: return (1400 - Elo);
                case 7: return (1550 - Elo);
                case 8: return (1700 - Elo);
                case 9: return (1850 - Elo);
                default: return (800 - Elo);
            }
        }

        private void btnPImage_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.faceit.com/en/players/" + Username);
        }

        private static void ShowSplash()
        {
            Processing sp = new Processing();
            sp.Show();
            Application.DoEvents();

            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler((sender, ea) =>
            {
                sp.BeginInvoke(new Action(() =>
                {
                    if (sp != null && Application.OpenForms.Count > 1)
                    {
                        sp.Close();
                        sp.Dispose();
                        sp = null;
                        t.Stop();
                        t.Dispose();
                        t = null;
                    }
                }));
            });
            t.Start();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread splashthread = new Thread(new ThreadStart(SplashScreen.ShowSplashScreen));
            splashthread.IsBackground = true;
            splashthread.Start();
            LoadForm(Username);
            this.Show();
            SplashScreen.CloseSplashScreen();
            this.Activate();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            //NEEDS FIXING: EXIT THE PLAYERSTATS FORM THEN OPEN THE SPLASHSCREEN AND OPEN THE ENTER PLAYER USERNAME
            //this.Hide();
            //PlayerStats active = this;
            //Thread splashthread = new Thread(new ThreadStart(SplashScreen.ShowSplashScreen));
            //splashthread.IsBackground = true;
            //splashthread.Start();
            //LoadForm(Username);
            //Form1 form = new Form1();
            //form.Show();
            //SplashScreen.CloseSplashScreen();
            //form.Activate();
        }
    }
}

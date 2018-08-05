using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faceit_Stats
{
    public partial class Form1 : Form
    {
        Point mouseLoc;
        string api_key = "c610a884-dcf9-474c-86a1-6fa5178018ca";
        string json;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(txtUser.Text.Length > 1)
            {
                try
                {
                    WebRequest req = WebRequest.Create("https://open.faceit.com/data/v4/players?nickname=" + txtUser.Text);
                    if (req != null)
                    {
                        req.Method = "GET";
                        req.Timeout = 12000;
                        req.ContentType = "application/json";
                        req.Headers.Add("Authorization", "Bearer " + api_key);

                        using (Stream s = req.GetResponse().GetResponseStream())
                        {
                            using (StreamReader sr = new StreamReader(s))
                            {
                                json = sr.ReadToEnd();
                            }
                        }
                    }
                    JObject objects = JObject.Parse(json); // parse as array  
                    if (objects.SelectToken("steam_id_64").ToString() == "")
                        throw new Exception("The specified user didn't setup his accout!");

                    PlayerStats form = new PlayerStats(json);
                    this.Hide();
                    form.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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

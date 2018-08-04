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

                    PlayerStats form = new PlayerStats(json);
                    this.Hide();
                    form.ShowDialog();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}

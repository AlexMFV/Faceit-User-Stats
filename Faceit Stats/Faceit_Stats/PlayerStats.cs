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

        private void PlayerStats_Load(object sender, EventArgs e)
        {
            btnPImage.Image = GetImage();
        }

        public Image GetImage()
        {
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(pImage.Text);
                Image imagem = Image.FromStream(stream);

                stream.Flush();
                stream.Close();
                client.Dispose();

                return imagem;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occurred!");
                return null;
            }
        }

        public  GetFromJsonString(string str, )
        {
        var objects = JArray.Parse(json); // parse as array  
    foreach(JObject root in objects)
    {
        foreach(KeyValuePair<String, JToken> app in root)
        {
            var appName = app.Key;
        var description = (String)app.Value["Description"];
        var value = (String)app.Value["Value"];

        Console.WriteLine(appName);
            Console.WriteLine(description);
            Console.WriteLine(value);
            Console.WriteLine("\n");
        }
}
}
    }
}

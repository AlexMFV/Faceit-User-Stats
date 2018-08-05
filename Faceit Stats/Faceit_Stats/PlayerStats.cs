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
using Newtonsoft.Json.Linq;

namespace Faceit_Stats
{
    public partial class PlayerStats : Form
    {
        string json;
        Point mouseLoc;
        string flagURL1 = "https://cdn-frontend.faceit.com/web/7-1533408307/src/app/assets/images-compress/flags/";
        string globalURL1 = "https://cdn-frontend.faceit.com/web/7-1533408307/src/app/assets/images-compress/region-flags/";
        string crURL = "https://open.faceit.com/data/v4/rankings/games/csgo/regions/";

        #region Variaveis

        Image pImage; //Imagem do Jogador
        string inGameName;
        Image Flag;
        Image GlobalFlag;
        int skillLevel; // 1-10 level
        string currRegion;
        string currCountry;
        string pID;
        int countryRank;
        int regionRank;

        #endregion

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
            GetJsonValues();

            btnPImage.Image = pImage; //Set Player Image
            lblIGN.Text = inGameName; //Set Player Ingame Name
            btnFlag.Image = Flag;
            btnRegion.Image = Flag;
            btnGlobalFlag.Image = GlobalFlag;

        }

        public Image GetPlayerImage(string imgURL)
        {
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(imgURL);
                Image imagem = Image.FromStream(stream);

                stream.Flush();
                stream.Close();
                client.Dispose();

                return imagem;
            }
            catch (Exception ex)
            {
                return Properties.Resources.NoImg;
            }
        }

        public void GetPlayerRanking()
        {
            string regiao;

            if (currRegion == "OC")
                regiao = "Oceania";
            else
                regiao = currRegion;


            if (regiao != "")
            {
                JObject ranks = JObject.Parse(GetNewWebRequest(crURL + regiao +
                    "/players/" + pID + "?country=" +
                    currCountry.ToLower() + "&limit=1"));

                countryRank = (int)ranks.SelectToken("position");

                ranks = JObject.Parse(GetNewWebRequest(crURL + regiao +
                    "/players/" + pID + "?limit=1"));

                regionRank = (int)ranks.SelectToken("position");
            }
        }

        public string GetNewWebRequest(string http)
        {
            string api_key = "c610a884-dcf9-474c-86a1-6fa5178018ca";
            try
            {
                WebRequest req = WebRequest.Create(http);
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
                return json;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        public void GetJsonValues()
        {
            try
            {
                JObject objects = JObject.Parse(json); // parse as array 
                pID = objects.SelectToken("player_id").ToString();
                foreach (KeyValuePair<string, JToken> root in objects)
                {
                    if ((string)root.Key == "avatar") //Get Player Image
                        if ((string)root.Value != "")
                            pImage = GetPlayerImage((string)root.Value);
                        else
                            pImage = Properties.Resources.NoImg;

                    if ((string)root.Key == "nickname")
                        inGameName = (string)root.Value;

                    if ((string)root.Key == "country")
                    {
                        currCountry = root.Value.ToString().ToUpper();
                        Flag = GetPlayerImage(flagURL1 + currCountry + ".png"); //@2x
                    }

                    if ((string)root.Key == "games" && root.Value.Count() != 0)
                    {
                        skillLevel = (int)root.Value.SelectToken("csgo").SelectToken("skill_level");
                        currRegion = root.Value.SelectToken("csgo").SelectToken("region").ToString().ToUpper();

                        if (currRegion == "OCEANIA")
                            currRegion = "OC";

                        GetPlayerRanking();

                        if (currRegion == "")
                        {
                            lblRegionRank.Text = "Unranked";
                            lblCountryRank.Text = "Unranked";
                            GlobalFlag = Properties.Resources.No_Flag;
                        }
                        else
                        {
                            GlobalFlag = GetPlayerImage(globalURL1 + currRegion + ".png");
                            lblCountryRank.Text = currCountry + ": " + countryRank.ToString("#,#");
                            lblRegionRank.Text = currRegion + ": " + regionRank.ToString("#,#");
                        }

                        prgLevel.Value = skillLevel;
                        lblPlayerLevel.Text = skillLevel.ToString();
                        prgLevel.ProgressColor = lblPlayerLevel.ForeColor = PaintLevel(skillLevel);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

        private void btnPImage_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.faceit.com/en/players/" + inGameName);
        }
    }
}

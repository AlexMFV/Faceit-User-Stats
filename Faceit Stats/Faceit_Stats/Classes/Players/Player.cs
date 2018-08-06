using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PR = Faceit_Stats.Properties.Resources;

namespace Faceit_Stats
{
    public class Player
    {
        #region Campos

        string _playerID;
        string _inGameName;
        Image _avatar;
        Image _flag;
        Image _globalFlag;
        int _skill_level;
        string _faceitURL;
        string _country;
        int _countryRank;
        int _regionRank;
        string _region;
        string _membership; //p = Premium, f = Free
        int _elo;

        #endregion

        #region Propriedades

        public string PlayerID
        {
            get { return _playerID; }
            set { _playerID = value; }
        }

        public string InGameName
        {
            get { return _inGameName; }
            set { _inGameName = value; }
        }

        public Image Avatar
        {
            get { return _avatar; }
            set { _avatar = value; }
        }

        public int Skill_Level
        {
            get { return _skill_level; }
            set { _skill_level = value; }
        }

        public string FaceitURL
        {
            get { return _faceitURL; }
            set { _faceitURL = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string Membership
        {
            get { return _membership; }
            set { _membership = value; }
        }

        public int ELO
        {
            get { return _elo; }
            set { _elo = value; }
        }

        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }

        public Image Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }

        public Image GlobalFlag
        {
            get { return _globalFlag; }
            set { _globalFlag = value; }
        }

        public int CountryRank
        {
            get { return _countryRank; }
            set { _countryRank = value; }
        }

        public int RegionRank
        {
            get { return _regionRank; }
            set { _regionRank = value; }
        }

        #endregion

        #region Construtores

        internal Player(string pID, bool IsLobby)
        {
            string json = GetNewWebRequest("https://open.faceit.com/data/v4/players/" + pID);
            GetJsonValues(json, IsLobby);
        }

        internal Player(string nickname)
        {
            string json = GetNewWebRequest("https://open.faceit.com/data/v4/players?nickname=" + nickname);
            GetJsonValues(json);
        }

        private Player() { }

        #endregion

        #region Metodos

        public string GetNewWebRequest(string http)
        {
            string api_key = "c610a884-dcf9-474c-86a1-6fa5178018ca";
            string json = "";
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
                return "";
            }
        }

        public void GetJsonValues(string json, bool IsLobby)
        {
            try
            {
                JObject objects = JObject.Parse(json); // parse as array
                foreach (KeyValuePair<string, JToken> root in objects)
                {
                    if (root.Key == "player_id")
                        PlayerID = (string)root.Value;

                    if (root.Key == "avatar" && IsLobby)
                        if ((string)root.Value != "")
                            Avatar = GetPlayerImage((string)root.Value);
                        else
                            Avatar = Properties.Resources.NoImg;

                    if (root.Key == "nickname")
                        InGameName = (string)root.Value;

                    if (root.Key == "country")
                    {
                        Country = root.Value.ToString().ToUpper();
                        Flag = GetPlayerImage(PR.FlagURL + Country + ".png"); //@2x
                    }

                    if (root.Key == "games" && root.Value.Count() != 0)
                    {
                        Skill_Level = (int)root.Value.SelectToken("csgo").SelectToken("skill_level");
                        Region = root.Value.SelectToken("csgo").SelectToken("region").ToString().ToUpper();
                        ELO = (int)root.Value.SelectToken("csgo").SelectToken("faceit_elo");

                        if (Region == "OCEANIA")
                            Region = "OC";

                        GetPlayerRanking();

                        if (Region == "")
                            GlobalFlag = PR.No_Flag;
                        else
                            GlobalFlag = GetPlayerImage(PR.RegionFlagURL + Region + ".png");
                    }

                    if (root.Key == "membership_type")
                        Membership = (string)root.Value.First();
                }

                FaceitURL = "https://www.faceit.com/en/players/" + InGameName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        } //Para matches e lobbies (pode nao ter imagem)

        public void GetJsonValues(string json)
        {
            try
            {
                JObject objects = JObject.Parse(json); // parse as array
                foreach (KeyValuePair<string, JToken> root in objects)
                {
                    if (root.Key == "player_id")
                        PlayerID = (string)root.Value;

                    if (root.Key == "avatar")
                        if ((string)root.Value != "")
                            Avatar = GetPlayerImage((string)root.Value);
                        else
                            Avatar = Properties.Resources.NoImg;

                    if (root.Key == "nickname")
                        InGameName = (string)root.Value;

                    if (root.Key == "country")
                    {
                        Country = root.Value.ToString().ToUpper();
                        Flag = GetPlayerImage(PR.FlagURL + Country + ".png");
                    }

                    if (root.Key == "games" && root.Value.Count() != 0)
                    {
                        Skill_Level = (int)root.Value.SelectToken("csgo").SelectToken("skill_level");
                        Region = root.Value.SelectToken("csgo").SelectToken("region").ToString().ToUpper();
                        ELO = (int)root.Value.SelectToken("csgo").SelectToken("faceit_elo");

                        if (Region == "OCEANIA")
                            Region = "OC";

                        GetPlayerRanking();

                        if (Region == "")
                            GlobalFlag = PR.No_Flag;
                        else
                            GlobalFlag = GetPlayerImage(PR.RegionFlagURL + Region + ".png");
                    }

                    if (root.Key == "membership_type")
                        Membership = (string)root.Value;
                }

                FaceitURL = "https://www.faceit.com/en/players/" + InGameName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        } //Para Nickname

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

            if (Region == "OC")
                regiao = "Oceania";
            else
                regiao = Region;

            if (regiao != "")
            {
                JObject ranks = JObject.Parse(GetNewWebRequest(PR.RankingURL + regiao +
                    "/players/" + PlayerID + "?country=" +
                    Country.ToLower() + "&limit=1"));

                CountryRank = (int)ranks.SelectToken("position");

                ranks = JObject.Parse(GetNewWebRequest(PR.RankingURL + regiao +
                    "/players/" + PlayerID + "?limit=1"));

                RegionRank = (int)ranks.SelectToken("position");
            }
        }

        #endregion
    }
}

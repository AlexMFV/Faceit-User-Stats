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

        public PlayerStats(string jsonString)
        {
            InitializeComponent();
            json = jsonString;
        }

        private void PlayerStats_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

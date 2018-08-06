using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Faceit_Stats
{
    public static class SplashScreen
    {
        static Processing sf = null;

        public static void ShowSplashScreen()
        {
            if (sf == null)
            {
                sf = new Processing();
                sf.ShowSplashScreen();
            }
        }

        public static void CloseSplashScreen()
        {
            if (sf != null)
            {
                sf.CloseSplashScreen();
                sf = null;
            }
        }
    }
}

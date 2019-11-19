using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ProblemaPartial1Desenat
{
    public static partial class Engine
    {
        public static int resX, resY;
        public static Bitmap bmp;
        public static Graphics grp;
        public static Color bckcolor = Color.Aquamarine;
        public static PictureBox display;

        public static void initGraph(PictureBox t)
        {
            display = t;
            resX = t.Width;
            resY = t.Height;
            bmp = new Bitmap(resX, resY);
            grp = Graphics.FromImage(bmp);
            clearGraph();
            refreshGraph();
        }

        public static void refreshGraph()
        {
            display.Image = bmp;
        }

        public static void clearGraph()
        {
            grp.Clear(bckcolor);
        }
    }
}

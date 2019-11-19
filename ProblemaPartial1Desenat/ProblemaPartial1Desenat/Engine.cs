using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace ProblemaPartial1Desenat
{
    public static partial class Engine
    {
        public static int n;
        public static int[,] ma;
        public static Node[] nodes;
        public static Color[] defaultColor = new Color[] { Color.Red, Color.Yellow, Color.Black, Color.Pink, Color.Green };

        public static void Load(string path)
        {
            TextReader dataLoad = new StreamReader(path);
            n = int.Parse(dataLoad.ReadLine());
            ma = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    ma[i, j] = 0;
                }
            }
            string buffer;
            while ((buffer = dataLoad.ReadLine()) != null)
            {
                int x = int.Parse(buffer.Split(' ')[0]);
                int y = int.Parse(buffer.Split(' ')[1]);
                ma[x, y] = ma[y, x] = 1;
            }
        }

        public static List<string> View()
        {
            string buffer;
            List<string> tr = new List<string>();
            for (int i = 0; i < n; i++)
            {
                buffer = "";
                for (int j = 0; j < n; j++)
                {
                    buffer += ma[i, j].ToString();
                }
                tr.Add(buffer);
            }
            return tr;
        }

        public static void initNode()
        {
            nodes = new Node[n];
            float angle = (float)(Math.PI * 2) / (float)n;
            for (int i = 0; i < n; i++)
            {
                float x = Engine.resX / 2 + 150 * (float)Math.Cos(i * angle);
                float y = Engine.resY / 2 + 150 * (float)Math.Sin(i * angle);
                nodes[i] = new Node(i.ToString(), new PointF(x, y));
            }
        }

        public static void drawMap()
        {
            for (int i = 0; i < n; i++)
            {
                nodes[i].Draw();
            }
            refreshGraph();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (ma[i, j] == 1)
                    {
                        Engine.grp.DrawLine(Pens.DarkBlue, nodes[i].loc, nodes[j].loc);
                    }
                }
            }
        }
    }
}

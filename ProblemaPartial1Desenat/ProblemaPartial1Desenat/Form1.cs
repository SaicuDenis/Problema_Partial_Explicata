using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProblemaPartial1Desenat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void back(int k, int n, int[] s)
        {
            if (k >= n)
            {
                bool ok = true;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (Engine.ma[i, j] == 1 && s[i] == s[j])
                        {
                            ok = false;
                            break;
                        }
                    }
                }
                if (ok)
                {
                    string t = "";
                    for (int i = 0; i < n; i++)
                    {
                        t += s[i].ToString();
                    }
                    listBox1.Items.Add(t);
                    for (int i = 0; i < n; i++)
                    {
                        Engine.nodes[i].bckcolor = Engine.defaultColor[s[i]];
                    }
                    Engine.drawMap();
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    s[k] = i;
                    back(k + 1, n, s);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Load(@"../../Resource/Grafuri/demo.txt");
            foreach (string s in Engine.View())
            {
                listBox1.Items.Add(s);
            }
            Engine.initGraph(pictureBox1);
            Engine.initNode();
            Engine.drawMap();
            int[] sol = new int[Engine.n];
            back(0, Engine.n, sol);
        }
    }
}

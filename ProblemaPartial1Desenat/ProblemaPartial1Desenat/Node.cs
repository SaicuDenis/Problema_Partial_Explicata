using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProblemaPartial1Desenat
{
    public class Node
    {
        public Color bckcolor;
        public PointF loc;
        public string name;

        public Node(string name, PointF loc)
        {
            this.name = name;
            this.loc = loc;
        }

        public void Draw()
        {
            Engine.grp.FillEllipse(new SolidBrush(bckcolor), loc.X - 5, loc.Y - 5, 11, 11);
            Engine.grp.DrawEllipse(Pens.Red, loc.X - 5, loc.Y - 5, 11, 11);
            Engine.grp.DrawString(name, new Font("Arial", 15, FontStyle.Regular), new SolidBrush(Color.Black), loc);
        }
    }
}

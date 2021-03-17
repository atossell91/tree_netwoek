using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tree_netwoek
{
    public partial class Form1 : Form
    {
        int mouse_x;
        int mouse_y;

        List<Node> nodes;
        List<Node> selected;
        public Form1()
        {
            nodes = new List<Node>();
            selected = new List<Node>();
            InitializeComponent();
        }


        private void Panel1_Click(object sender, EventArgs e)
        {
            foreach (Node nd in nodes)
            {
                if (nd.isInBounds(mouse_x, mouse_y))
                {
                    if (selected.Count < 1)
                    {
                        selected.Add(nd);
                    }
                    else
                    {
                        nd.connections.Add(selected[0]);
                        this.Refresh();
                        selected.Clear();
                    }
                    return;
                }
            }
            Point p = bound.findTopLeft(mouse_x, mouse_y, Node.DIAMETER, Node.DIAMETER);
            Node n = new Node(p.X, p.Y);
            nodes.Add(n);
            panel1.Refresh();
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Node n in nodes)
            {
                Brush b = new SolidBrush(n.color);
                Rectangle r = new Rectangle(n.pos_x, n.pos_y, Node.DIAMETER, Node.DIAMETER);
                e.Graphics.FillEllipse(b, r);
                foreach (Node nd in n.connections)
                {
                    Pen p = new Pen(new SolidBrush(Color.Black));
                    p.Width = 4.0f;
                    Point p1 = bound.findCentre(n.pos_x, n.pos_y, bound.DIAMETER, bound.DIAMETER);
                    Point p2 = bound.findCentre(nd.pos_x, nd.pos_y, bound.DIAMETER, bound.DIAMETER);
                    e.Graphics.DrawLine(p, p1.X, p1.Y, p2.X, p2.Y);
                }
            }
        }
    }
}

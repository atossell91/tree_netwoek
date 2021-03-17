using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree_netwoek
{
    class bound
    {
        public static readonly int DIAMETER = 40;

        public int pos_x;
        public int pos_y;

        public Color color = Color.Black;

        int leftEdge()
        {
            return pos_x;
        }
        int rightEdge()
        {
            return pos_x + DIAMETER;
        }
        int topEdge()
        {
            return pos_y;
        }
        int bottomEdge()
        {
            return pos_y + DIAMETER;
        }
        public bool isInBounds(int x, int y)
        {
            bool horz = (x >= leftEdge()) && ( x <= rightEdge());
            bool vert = (y >= topEdge()) && (y <= bottomEdge());

            return horz && vert;
        }

        public static Point findCentre(int x, int y, int width, int height)
        {
            int out_x = x + width / 2;
            int out_y = y + height / 2;
            return new Point(out_x, out_y);
        }
        public static Point findTopLeft(int x, int y, int width, int height)
        {
            int out_x = x - width / 2;
            int out_y = y - height / 2;
            return new Point(out_x, out_y);
        }
    }
}

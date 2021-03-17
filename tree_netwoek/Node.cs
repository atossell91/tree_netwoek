using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree_netwoek
{
    class Node : bound
    {
        public List<Node> connections;
        public Node(int x, int y)
        {
            connections = new List<Node>();
            pos_x = x;
            pos_y = y;
        }
    }
}

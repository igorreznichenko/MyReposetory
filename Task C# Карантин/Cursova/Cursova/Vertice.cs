using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursova
{
   public class Vertice
    {
        public Vertice(int x, int y, int n, decimal Weight = 0)
        {
            this.x = x;
            this.y = y;
            pos = n;
            next = null;
            this.Weight = Weight;
        }
        public Vertice(Vertice v, decimal Weight)
        {
            x = v.x;
            y = v.y;
            pos = v.pos;
            this.Weight = Weight;
            next = null;
        }
        public int pos;
        public int x, y;
        public Vertice next;
        public decimal Weight;
    }


}

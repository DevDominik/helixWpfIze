using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Gyongy
    {
        private int x, y, z, e;

        public Gyongy(int x, int y, int z, int e) 
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.e = e;
        }

        public int X { get { return x; } }
        public int Y { get { return y; } }
        public int Z { get { return z; } }
        public int E { get { return e; } }
    }
}

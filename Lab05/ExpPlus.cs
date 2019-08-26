using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class ExpPlus : Exp
    {
        public int a;
        public int b;

        public ExpPlus(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
    }
}

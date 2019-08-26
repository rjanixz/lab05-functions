using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class PrintDef : Statement
    {
        Exp exp;

        public PrintDef(Exp exp)
        {
            this.exp = exp;
        }
    }
}

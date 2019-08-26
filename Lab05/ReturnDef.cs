using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class ReturnDef : Statement
    {

        Exp exp;

        public ReturnDef(Exp exp)
        {
            this.exp = exp;
        }
    }
}

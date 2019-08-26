using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class VarDef : Statement
    {
        public String id;

        public VarDef(String id)
        {
            this.id = id;
        }
    }
}

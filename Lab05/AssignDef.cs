using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class AssignDef : Statement
    {
        public String id;
        public Exp exp;

        public AssignDef(String id, Exp exp)
        {
            this.id = id;
            this.exp = exp;
        }
    }
}

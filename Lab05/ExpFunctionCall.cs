using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class ExpFunctionCall : Exp
    {
        public String id;
        public List<Exp> exp_list = new List<Exp>();

        public ExpFunctionCall(String id, List<Exp> exp_list) {
            this.id = id;
            this.exp_list = exp_list;
        }
    }
}

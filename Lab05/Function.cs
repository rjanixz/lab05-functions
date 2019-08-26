using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{

    class Function
    {
        public String id;
        public List<String> param_list = new List<String>();

        // cuerpo de la funcion
        // bloque de sentencias
        public List<Statement> block = new List<Statement>();

        public Function(String id, List<String> param_list, List<Statement> block)
        {
            this.id = id;
            this.param_list = param_list;
            this.block = block;
        }
    }
}

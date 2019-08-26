using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class Collector
    {
        private static List<Statement> statements = new List<Statement>();

        private static List<Function> functions = new List<Function>();


        public static Function getFunction(String id)
        {
            foreach(Function function in functions)
            {
                if (function.id == id)
                {
                    return function;
                }
            }

            throw new Exception("La funcion " + id + " no ha sido definida");
        }


        public static void addStatement(Statement statement)
        {
            statements.Add(statement);
        }

        public static void addFunction(Function function)
        {
            // TODO validar si el ID es valido
            functions.Add(function);
        }

        public static List<Statement> getStatements()
        {
            return statements;
        }
    }
}

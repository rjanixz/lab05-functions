using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class Program
    {
        static void Main(string[] args)
        {
            String input = "var a; a= 5; print(a);";

            Evaluator evaluator = new Evaluator();
            evaluator.evaluate(input);


            evaluateStatement(Collector.getStatements());
        }

        public static void evaluateStatement(List<Statement> statements)
        {
            foreach (Statement statemet in statements)
            {
                if (statemet.GetType() == typeof(VarDef))
                {
                    procesarVarDef((VarDef)statemet);
                }
                else if (statemet.GetType() == typeof(AssignDef))
                {
                    procesarAssingDef((AssignDef)statemet);
                }
                else if (statemet.GetType() == typeof(Function))
                {
                    // validar, el nombre no este duplicado
                }
            }
        }


        public static void procesarVarDef(VarDef varDef)
        {
            String id = varDef.id;

            // TODO insertar este ID en la tabla de simbolos
        }

        public static void procesarAssingDef(AssignDef assingDef)
        {
            String id = assingDef.id;
            Exp exp = assingDef.exp;

            // TODO evaluar exp
            // TODO actualizar la tabla de simbolos con el valor y el ID
        }



        public static int procesarEXp(Exp exp)
        {
            if (exp.GetType() == typeof(ExpNumber))
            {
                return ((ExpNumber)exp).value;
            } else if (exp.GetType() == typeof(ExpPlus))
            {
                int a = ((ExpPlus)exp).a;
                int b = ((ExpPlus)exp).b;
                return a + b ;
            }
            else if (exp.GetType() == typeof(ExpId))
            {
                // TODO leer de la tabla de simbpos
                return -50;
            }
            else if (exp.GetType() == typeof(ExpFunctionCall))
            {
                ExpFunctionCall expFunc = (ExpFunctionCall)exp;

                String id = expFunc.id;

                Function function = Collector.getFunction(id);

                evaluateStatement(function.block);
            }



            return -1;
        }
    }
}

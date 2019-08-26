using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class Lab05Grammar : Irony.Parsing.Grammar
    {

        public Lab05Grammar() : base(false) {

            var NUMBER = new NumberLiteral("Number");
            var ID = new IdentifierTerminal("ID");
            var VAR = ToTerm("var");
            var PRINT = ToTerm("print");
            var RETURN = ToTerm("return");
            var FUNCTION = ToTerm("function");

            var COMMA = ToTerm(",");
            var PLUS = ToTerm("+");
            var SEMI_COLON = ToTerm(";");
            var OPEN_PAR = ToTerm("(");
            var CLOSED_PAR = ToTerm(")");
            var OPEN_BRACE = ToTerm("{");
            var CLOSED_BRACE = ToTerm("}");
            var EQ = ToTerm("=");

            var start = new NonTerminal("Start");
            var main = new NonTerminal("Main");
            var root_statement = new NonTerminal("RootStatement");
            var var_def = new NonTerminal("VarDef");
            var assign_def = new NonTerminal("AssignDef");
            var print_def = new NonTerminal("PrintDef");
            var return_def = new NonTerminal("ReturnDef");

            var function_def = new NonTerminal("FunctionDef");
            var params_list = new NonTerminal("ParamsList");
            

            var block = new NonTerminal("Block");
            var statements_list = new NonTerminal("StatementList");
            var statement = new NonTerminal("Statement");

            var exp = new NonTerminal("Exp");
            var exp_list = new NonTerminal("ExpList");



            start.Rule = main;

            main.Rule = main + root_statement
                | root_statement
                ;

            root_statement.Rule = var_def
                | assign_def
                | print_def
                | function_def
                ;

            // definción de variables
            var_def.Rule = VAR + ID + SEMI_COLON;

            // asignación de variables
            assign_def.Rule = ID + EQ + exp + SEMI_COLON;

            // función imprimir
            print_def.Rule = PRINT + OPEN_PAR + exp + CLOSED_PAR + SEMI_COLON;

            // return 
            return_def.Rule = RETURN + exp;

            // definicion de funciones 
            function_def.Rule = FUNCTION + ID +  OPEN_PAR + params_list + CLOSED_PAR + block;

            params_list.Rule = params_list + COMMA + VAR + ID
                | VAR + ID
                ;

            block.Rule = OPEN_BRACE + statements_list + CLOSED_BRACE;

            statements_list.Rule = statements_list + statement
                | statement;

            statement.Rule = var_def | assign_def | print_def | return_def;

            exp.Rule = NUMBER
                    | exp + PLUS + exp
                    | ID
                    | ID + OPEN_PAR + exp_list + CLOSED_PAR
                    ;

            exp_list.Rule = exp_list + COMMA + exp
                | exp;

            RegisterBracePair("{", "}");
            RegisterBracePair("(", ")");
            MarkPunctuation(",", ";", "+", "=", "(", ")", "{", "}", VAR.Text, PRINT.Text, FUNCTION.Text);

            this.Root = start;
        }
    }
}

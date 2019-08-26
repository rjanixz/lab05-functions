using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class Evaluator
    {
        public void evaluate(String input)
        {
            var language = new LanguageData(new Lab05Grammar());
            var parser = new Parser(language);
            var syntaxTree = parser.Parse(input);   // evaluó la entrada

            if (syntaxTree.HasErrors())
            {
                Console.WriteLine("ERROR:");
                Console.WriteLine(syntaxTree.ParserMessages[0].Message);
                return;
            }
            else
            {
                evaluateMain(syntaxTree.Root);
            }
        }

        public void evaluateMain(ParseTreeNode main)
        {
            if (main.ChildNodes.Count == 2)
            {
                evaluateMain(main.ChildNodes[0]);
                evaluateRootStatement(main.ChildNodes[1]);
            } else
            {
                //
                evaluateRootStatement(main.ChildNodes[0]);
            }
        }

        public void evaluateRootStatement(ParseTreeNode rootStatement)
        {
            Statement statement = null;
            if (rootStatement.Term.Name == "VarDef")
            {
                statement = evaluateVarDef(rootStatement);
            } else if (rootStatement.Term.Name == "VarDef")
            {
                statement = evaluateAssignDef(rootStatement);
            }
            else if(rootStatement.Term.Name == "PrintDef")
            {
                statement =  evaluatePrintDef(rootStatement);
            } else if (rootStatement.Term.Name == "FunctionDef")
            {
                evaluateFunctionDef(rootStatement);
            }

            if (statement != null)
            {
                Collector.addStatement(statement);
            }
        }

        public Statement evaluateVarDef(ParseTreeNode varDefNode)
        {
            return new VarDef(varDefNode.ChildNodes[0].Token.ValueString);
        }

        public Statement evaluateAssignDef(ParseTreeNode assignDefNode)
        {
            String id = assignDefNode.ChildNodes[0].Token.ValueString;
            Exp exp = evaluateExp(assignDefNode.ChildNodes[1]);

            return new AssignDef(id, exp);
        }

        public Statement evaluatePrintDef(ParseTreeNode printDefNode)
        {
            Exp exp = evaluateExp(printDefNode.ChildNodes[0]);
            return new PrintDef(exp);
        }

        public void evaluateFunctionDef(ParseTreeNode functionDefNode)
        {
            String id = functionDefNode.ChildNodes[0].Token.ValueString;
            List<String> params_list = new List<String>();
            evaluateParamsList(params_list, functionDefNode.ChildNodes[1]);
            List<Statement> statement_list = evaluateBlock(functionDefNode.ChildNodes[2]);

            Function function = new Function(id, params_list, statement_list);
            Collector.addFunction(function);
        }

        public  void evaluateParamsList(List<String> result, ParseTreeNode paramsListNode)
        {
            if (paramsListNode.ChildNodes.Count == 2)
            {
                evaluateParamsList(result, paramsListNode.ChildNodes[0]);

                // colecto el valor
                result.Add(paramsListNode.ChildNodes[1].Token.ValueString);
            }
            else
            {
                // colecto el valor
                result.Add(paramsListNode.ChildNodes[0].Token.ValueString);
            }
        }

        public List<Statement> evaluateBlock(ParseTreeNode blockNode)
        {
            List<Statement> statement_list = new List<Statement>();
            evaluateStatementList(statement_list, blockNode.ChildNodes[0]);

            return statement_list;
        }

        public void evaluateStatementList(List<Statement> statement_list, ParseTreeNode statementNode)
        {
            if (statementNode.ChildNodes.Count == 2)
            {
                evaluateStatementList(statement_list, statementNode.ChildNodes[0]);
                Statement statement = evaluateStatement(statementNode.ChildNodes[1]);
                statement_list.Add(statement);
            }
            else
            {
                Statement statement = evaluateStatement(statementNode.ChildNodes[0]);
                statement_list.Add(statement);
            }
        }

        public Statement evaluateStatement(ParseTreeNode statementNode)
        {
            if (statementNode.Term.Name == "VarDef")
            {
                return evaluateVarDef(statementNode);
            }
            else if (statementNode.Term.Name == "VarDef")
            {
                return evaluateAssignDef(statementNode);
            }
            else if (statementNode.Term.Name == "PrintDef")
            {
                return evaluatePrintDef(statementNode);
            }
            else if (statementNode.Term.Name == "ReturnDev")
            {
                return null; // TODO
            } else
            {
                throw new Exception("ERROR: Nodo inválido");
            }

        }


        public Exp evaluateExp(ParseTreeNode expNode)
        {
            // TODO
            return new ExpNumber(10); 
        }
    }
}

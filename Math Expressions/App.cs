using System;
using System.Collections.Generic;
using System.Text;
using Math_Expressions;

namespace Math_Expressions
{
    public static class App
    {
        public static void Run(string[] args) 
        {
            while (true)
            {
                Console.WriteLine("Please Enter Your Math Expression");
                var input = Console.ReadLine();
                var expr = Expression_Parser.Parse(input);
                Console.WriteLine($"Leftside = {expr.LeftSideOperand} , operation = {expr.operation} , Rightside = {expr.RightSideOperand} ");
                Console.WriteLine($"{input} = {EvaluateExpression(expr)}");
            }
        }

        private static object EvaluateExpression(Math_ex expr)
        {
            if (expr.operation == Math_Operation.Addition)
                return expr.LeftSideOperand + expr.RightSideOperand;
            else if (expr.operation == Math_Operation.Subtraction)
                return expr.LeftSideOperand - expr.RightSideOperand;
            else if (expr.operation == Math_Operation.Multiplication)
                return expr.LeftSideOperand * expr.RightSideOperand;
            else if (expr.operation == Math_Operation.Modulus)
                return expr.LeftSideOperand % expr.RightSideOperand;
            else if (expr.operation == Math_Operation.Division)
                return expr.LeftSideOperand / expr.RightSideOperand;
            else if (expr.operation == Math_Operation.Power)
                return Math.Pow(expr.LeftSideOperand,expr.RightSideOperand);
            else if (expr.operation == Math_Operation.Power)
                return Math.Sin( expr.RightSideOperand);
            else if (expr.operation == Math_Operation.Power)
                return Math.Cos(expr.RightSideOperand);
            else if (expr.operation == Math_Operation.Power)
                return Math.Tan(expr.RightSideOperand);

            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Math_Expressions
{
    public static class Expression_Parser
    {
        private const string Mathsymbols = "+*/^%";

        // ana  3mlt 7aga hena 
        
        public static Math_ex Parse(string input)
        {
            string token = "";
            bool leftsideinitialized = false;
            var expr = new Math_ex();
            for (var i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];
                
                if (char.IsDigit(currentChar))
                {
                    token += currentChar;

                    if (i == input.Length - 1 && leftsideinitialized) 
                    {
                        expr.RightSideOperand = double.Parse(token);
                        break;
                    }
                }
                else if (Mathsymbols.Contains(currentChar))
                {
                    if (!leftsideinitialized)
                    {
                        expr.LeftSideOperand = double.Parse(token);
                        leftsideinitialized = true;
                      
                    }
                    expr.operation = ParseMath_Operation(currentChar.ToString());
                    token = " ";
                }

                else if (char.IsLetter(currentChar))
                {
                    token += currentChar;
                    leftsideinitialized = true; 
                }
                else if (currentChar == '-' && i > 0)
                {
                    if (expr.operation == Math_Operation.None)
                    {
                        expr.operation = Math_Operation.Subtraction;
                        expr.LeftSideOperand = double.Parse(token);
                        leftsideinitialized = true;
                        token = "";

                    }

                    else
                        token += currentChar;
                    
                }
                else if (currentChar == ' ')
                {
                    if (!leftsideinitialized)
                    {
                        expr.LeftSideOperand = double.Parse(token);
                        leftsideinitialized = true; 
                        token = "";

                    }

                    else if (expr.operation == Math_Operation.None)
                    {
                        expr.operation = ParseMath_Operation(token);
                        token = "";
                    }
                }

                else
                    token += currentChar;
               
            }
             
            
            return expr;
        }

        private static Math_Operation ParseMath_Operation(string token)
        {
            switch (token.ToLower()) 
            {
                case "+":
                    return Math_Operation.Addition;

                case "/":
                    return Math_Operation.Division;
                case "%":
                case "Modulus":
                case "mod":
                    return Math_Operation.Modulus;
                case "*":
                    return Math_Operation.Multiplication;
                case "^":
                case "Pow":
                    return Math_Operation.Power;
                case "sin":
                    return Math_Operation.Sin;
                case "cos":
                    return Math_Operation.Cos;
                case "tan":
                    return Math_Operation.Tan;
                default:
                    return Math_Operation.None;

            } 
                
        }
    }
}

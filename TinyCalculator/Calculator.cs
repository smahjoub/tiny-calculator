using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCalculator
{
    /// <summary>
    /// Basic Calculator class
    /// </summary>
    public class Calculator
    {

        /// <summary>
        /// Evaluates a postfix expression and return decimal result.
        /// </summary>
        /// <param name="postfixExp"></param>
        /// <returns>The result of the evaluated expression</returns>
        public static decimal Evaluate(String postfixExp)
        {
            var tokens = postfixExp.Split(' ');
            var argumentsStack = new Stack<decimal>();
           
            foreach(var token in tokens)
            {
                var number = decimal.Zero;
                if (decimal.TryParse(token, out number))
                {
                    argumentsStack.Push(number);
                }
                else if (token.IsOperator())
                {
                    var a = argumentsStack.Pop();
                    var b = argumentsStack.Pop();
                    var result = decimal.Zero;

                    switch (token)
                    {
                        case "+":
                            result = b + a;
                            break;
                        case "-":
                            result = b - a;
                            break;
                        case "*":
                            result = b * a;
                            break;
                        case "/":
                            result = b / a;
                            break;
                        case "^":
                            result = Convert.ToDecimal(Math.Pow(Convert.ToDouble(b), Convert.ToDouble(a)));
                            break;
                        default:
                            throw new InvalidOperationException("The operator: " + token + " is invalid or not supported.");
                    }
                    argumentsStack.Push(result);
                }
            }

            return argumentsStack.Pop();
        }
    }
}
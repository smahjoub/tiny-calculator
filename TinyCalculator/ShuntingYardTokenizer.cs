using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCalculator
{
    /// <summary>
    /// Class that contains the implementation of the Shunting-Yard Algorithm
    /// </summary>
    public class ShuntingYardTokenizer
    {
        /// <summary>
        /// Converts an infix expression to a postfix expression using an implementation of the Shunting-Yard Algorithm
        /// </summary>
        /// <param name="infix">Infix expression to pars</param>
        /// <returns>Postix expression</returns>
        public string ToPostfix(string infix)
        {
            var tokens = infix.Split(' ');
            var stack  = new Stack<string>();
            var output = new List<string>();

            foreach (string token in tokens)
            {
                if (token.IsInteger())
                {
                    output.Add(token);
                }
                else if (token.IsOperator())
                {
                    var firstOp = token.GetOperator();

                    while (stack.Count > 0)
                    {
                        var stackTop = stack.Peek();
                        if (stackTop.IsOperator())
                        {
                            var secondOp = stackTop.GetOperator();
           
                            if (firstOp.Precedence <= secondOp.Precedence && firstOp.AssociativityType == AssociativityType.Left)
                            {
                                output.Add(stack.Pop());
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }

                    }

                    stack.Push(token);
                }
                else if (token.IsLeftParenthesis())
                {
                    stack.Push(token);
                }
                else if (token.IsRightParenthesis())
                {
                    var top = "";
                    while (stack.Count > 0 && !(top = stack.Pop()).IsLeftParenthesis())
                    {
                        output.Add(top);
                    }
                    if (!top.IsLeftParenthesis())
                    {
                        throw new ArgumentException("Missing left parenthesis.");
                    }
                        
                }
            }

            while (stack.Count > 0)
            {
                var top = stack.Pop();
                if (!top.IsOperator())
                {
                    throw new ArgumentException("Missing right parenthesis.");
                }
                output.Add(top);
            }


            var result = string.Join(" ", output);

            return result;
        }
    }
}

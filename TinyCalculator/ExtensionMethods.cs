using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCalculator
{
    public static class ExtensionMethods
    {
        private static readonly List<TokenOperator> tokenOperators;

        private static readonly string[] operators = { "^", "*", "/", "+", "-" };

        static ExtensionMethods()
        {
            tokenOperators = new List<TokenOperator>();

            tokenOperators.Add(new TokenOperator("^", 4, AssociativityType.Right));

            tokenOperators.Add(new TokenOperator("*", 3, AssociativityType.Left));

            tokenOperators.Add(new TokenOperator("/", 3, AssociativityType.Left));

            tokenOperators.Add(new TokenOperator("+", 2, AssociativityType.Left));

            tokenOperators.Add(new TokenOperator("-", 2, AssociativityType.Left));

        }


        public static bool IsInteger(this string input)
        {
            return int.TryParse(input, out _);
        }

        public static bool IsOperator(this string input)
        {
            return operators.Contains(input); 
        }

        public static TokenOperator GetOperator(this string input)
        {
            foreach(var tknOp in tokenOperators)
            {
                if (tknOp.Symbol.Equals(input))
                {
                    return tknOp;
                }
            }

            throw new ArgumentException("Could not find the equivalent operator."); 
        }

        public static bool IsLeftParenthesis(this string input)
        {
            return input == "(";
        }


        public static bool IsRightParenthesis(this string input)
        {
            return input == ")";
        }
    }
}

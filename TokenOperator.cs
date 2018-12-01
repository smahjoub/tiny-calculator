using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCalculator
{
    public struct TokenOperator
    {
        private readonly AssociativityType associativityType;

        private readonly int precedence;

        private readonly string symbol;

        public TokenOperator(string symb, int prcd, AssociativityType assocType)
        {
            symbol = symb;
            precedence = prcd;
            associativityType = assocType;
        }

        public AssociativityType AssociativityType
        {
            get { return associativityType; }
        }

        public int Precedence
        {
            get { return precedence;  }
        }

        public string Symbol
        {
            get { return symbol; }
        }
    }
}

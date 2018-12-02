using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var infix = "3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3";
            var tokenizer = new ShuntingYardTokenizer();

            Console.WriteLine(tokenizer.ToPostfix(infix));

            Console.ReadKey();
        }
    }
}

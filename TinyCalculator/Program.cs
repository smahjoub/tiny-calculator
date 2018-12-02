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

            Console.WriteLine("Input Expression: {0}", infix);

            var tokenizer   = new ShuntingYardTokenizer();
            
            try
            {
                var postFix = tokenizer.ToPostfix(infix);
                var output = Calculator.Evaluate(postFix);
                Console.WriteLine("RPN Expression: {0}", postFix);
                Console.WriteLine("Result : {0}", output);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something wrong happened: {0}", e.Message);
            }
           
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}

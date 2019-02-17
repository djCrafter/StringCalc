using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc calc = new Calc();

            while (true)
            {
                try
                {
                    Console.Write("Введите выражение: ");
                    string expression = Console.ReadLine();
                    Console.WriteLine("= " + calc.Calculate(expression));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}

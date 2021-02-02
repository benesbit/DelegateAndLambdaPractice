using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndLambdas
{
    public class ProcessData
    {
        public void Process(int x, int y, BizRulesDelegate del)
        {
            var result = del(x, y);
            Console.WriteLine($"{result}");
        }
    }
}

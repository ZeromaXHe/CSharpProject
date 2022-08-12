using System;
using ConsoleApplicationLeetCodeSolutions.from1to200;
using ConsoleApplicationLeetCodeSolutions.from201to400;
using ConsoleApplicationLeetCodeSolutions.from2201to2400;
using ConsoleApplicationLeetCodeSolutions.lcp;

namespace ConsoleApplicationLeetCodeSolutions
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // new Solution4().Test();
                // new Solution5().Test();
                // new SolutionLcp10().Test();
                // new Solution2328().Test();
                // new Solution322().Test();
                new Solution23().Test();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
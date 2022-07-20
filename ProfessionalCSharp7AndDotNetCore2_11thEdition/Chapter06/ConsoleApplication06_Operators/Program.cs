using System;

namespace ConsoleApplication06_Operators
{
    /// <summary>
    /// 第 6 章 运算符和类型强制转换
    /// </summary>
    internal class Program
    {
        public static void Main(string[] args)
        {
            test6_2_1();
            Console.WriteLine("-------");
        }

        /// <summary>
        /// 6.2.1 运算符的简化操作
        /// </summary>
        private static void test6_2_1()
        {
            int x = 5;
            if (++x == 6) // true - x is incremented to 6 before the evaluation
            {
                Console.WriteLine("This will execute");
            }

            if (x++ == 7) // false - x is incremented to 7 after the evaluation
            {
                Console.WriteLine("This won't");
            }

            // 1. 条件运算符
            int x2 = 1;
            string s = x + " ";
            s += (x == 1 ? "man" : "men");
            Console.WriteLine(s);

            // 3. is 运算符
            int i = 42;
            if (i is object)
            {
                Console.WriteLine("i is an object");
            }

            if (i is 42)
            {
                Console.WriteLine("i has the value 42");
            }

            object o = null;
            if (o is null)
            {
                Console.WriteLine("o is null");
            }
            
            // 4. as 运算符
            object o1 = "Some String";
            object o2 = 5;
            string s1 = o1 as string; // s1 = "Some String"
            string s2 = o2 as string; // s2 = null
            Console.WriteLine($"s1: {s1}");
            Console.WriteLine($"s2: {s2}");
            
            // 5. sizeof 运算符
            Console.WriteLine(sizeof(int)); // 4
        }
    }
}
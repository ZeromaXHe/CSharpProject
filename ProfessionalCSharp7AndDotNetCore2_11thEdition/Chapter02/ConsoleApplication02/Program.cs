using System;
using Introduction = Wrox.ProCSharp.Basics;

namespace ConsoleApplication02
{
    /**
     * 第 2 章 核心 C#
     */
    internal class Program
    {
        public static void Main(string[] args)
        {
            test2_2_2();
            Console.WriteLine("------------");
            test2_2_3();
            Console.WriteLine("------------");
            test2_3_4();
            Console.WriteLine("------------");
            test2_4_1();
            Console.WriteLine("------------");
            test2_4_2();
            Console.WriteLine("------------");
            test2_5_2();
        }

        /**
         * 2.2.2 类型推断
         */
        private static void test2_2_2()
        {
            var name = "Bugs Bunny";
            var age = 25;
            var isRabbit = true;
            Type nameType = name.GetType();
            Type ageType = age.GetType();
            Type isRabbitType = isRabbit.GetType();
            Console.WriteLine($"name is of type {nameType}");
            Console.WriteLine($"age is of type {ageType}");
            Console.WriteLine($"isRabbit is of type {isRabbitType}");
        }

        private static int j = 20;

        /**
         * 2.2.3 变量的作用域
         */
        private static void test2_2_3()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            for (int i = 9; i >= 0; i--)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            int j = 30;
            Console.WriteLine(j);
            Console.WriteLine(Program.j);
        }

        /**
         * 2.3.4 预定义的引用类型
         */
        private static void test2_3_4()
        {
            string s1 = "a string";
            string s2 = s1;
            Console.WriteLine("s1 is " + s1);
            Console.WriteLine("s2 is " + s2);
            s1 = "another string";
            Console.WriteLine("s1 is now " + s1);
            Console.WriteLine("s2 is now " + s2);
        }

        /**
         * 2.4.1 条件语句
         */
        private static void test2_4_1()
        {
            Console.WriteLine("Type in a string");
            string input;
            input = Console.ReadLine();
            if (input == "")
            {
                Console.WriteLine("You typed in an empty string.");
            }
            else if (input.Length < 5)
            {
                Console.WriteLine("The string had less than 5 characters.");
            }
            else if (input.Length < 10)
            {
                Console.WriteLine("The string had at least 5 but less than 10 Characters.");
            }

            Console.WriteLine("The string was " + input);
        }

        /**
         * 2.4.2 循环
         */
        private static void test2_4_2()
        {
            for (int i = 0; i < 100; i += 10)
            {
                for (int j = i; j < i + 10; j++)
                {
                    Console.Write($" {j}");
                }

                Console.WriteLine();
            }
        }

        /**
         * 2.5.2 名称空间的别名
         */
        private static void test2_5_2()
        {
            Introduction::NamespaceExample NSEx = new Introduction::NamespaceExample();
            Console.WriteLine(NSEx.GetNameSpace());
        }
    }
}

// 等于 namespace Wrox { namespace ProCSharp { namespace Basics {...}}}
namespace Wrox.ProCSharp.Basics
{
    class NamespaceExample
    {
        // Code for the class here ...
        public string GetNameSpace()
        {
            return this.GetType().Namespace;
        }
    }
}

// 2.7.2 XML 文档
// 除了 C 风格的注释外， C# 还有一个非常出色的功能：根据特定的注释自动创建 XML 格式的文档说明。
// 这些注释都是单行注释，但都以 3 条斜杠（///）开头，而不是通常的两条斜杠。
// 在这些注释中，可以把包含类型和类型成员的文档说明的 XML 标记放在代码中。
namespace Wrox.MathLib
{
    /// <summary>
    /// Wrox.MathLib.Calculator class.
    /// Provides a method to add two doubles.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// The Add method allows us to add two doubles.
        /// </summary>
        /// <param name="x">First number to add</param>
        /// <param name="y">Second number to add</param>
        /// <returns>Result of the addition (double)</returns>
        public static double Add(double x, double y) => x + y;
    }
}

// 2.8 C# 预处理器指令
// #define DEBUG // 它告诉编译器存在给定名称的符号，在本例中是 DEBUG
// #undef DEBUG // 它删除符号的定义
// #if DEBUG // 这行代码只有在前面的 #define 指令定义了符号 DEBUG 后才执行。否则，编译器会忽略所有的代码，直到遇到匹配的 #endif 为止
// #elif 和 #else 指令可以用在 #if 块中。也可以嵌套 #if 块
// #if 和 #elif 还支持一组逻辑运算符"!", "==", "!=", "||"。如果符号存在，就被认为是 true，否则为 false。
// #warning "warn" // 会向用户显示 #warning 后面的文本，之后编译继续进行。
// #error "err" // 向用户显示后面的文本，作为一条编译错误消息，然后会立即退出编译，不会生成 IL 代码。
// #region 和 #endregion 指令用于把一段代码视为有给定名称的一个块。可以被某些编译器识别，使代码在屏幕上更好地布局。
// #line 164 "Core.cs" // 指令可以用于改变编译器在警告和错误信息中显示的文件名和行号信息。
// #line default 把行号还原为默认的行号
// #pragma warning disable 169 // 抑制指定的编译警告
// #pragma warning restore 169 // 还原指定的编译警告
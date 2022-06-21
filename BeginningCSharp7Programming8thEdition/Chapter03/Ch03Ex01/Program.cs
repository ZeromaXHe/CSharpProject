using System;

namespace Ch03Ex01
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int myInteger;
            string myString;
            myInteger = 17;
            myString = "\"myInteger\" is";
            // 这是 C# 6 中的一个新功能，称为字符串插入（String Interpolation）
            Console.WriteLine($"{myString} {myInteger}");

            Console.WriteLine("--------------------");
            Test3_3_3();

            Console.ReadKey();
        }

        private static void Test3_3_3()
        {
            // 在 C# 7 中，可以直接以二进制的形式向 numbers 数组添加值
            // C# 7 中的新特性数字分隔符 _
            int[] numbers = {0b0001, 0b0010, 0b00100, 0b0001000, 0b00010000, 0b0010_0000, 0b0100_0000, 0b1000_0000};
            Console.WriteLine(string.Join(", ", numbers));
            // 一字不变的字符串需要在字符串前加一个 @ 字符
            Console.WriteLine(@"A short list:
item1
item2");
            Console.WriteLine("C:\\Temp\\MyDir\\MyFile.doc");
            Console.WriteLine(@"C:\Temp\MyDir\MyFile.doc");
        }
    }
}
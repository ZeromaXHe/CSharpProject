using System;
using static System.Console;
using static System.Convert;

namespace Ch05Ex01
{
    /**
     * 类型转换实践
     */
    internal class Program
    {
        public static void Main(string[] args)
        {
            short shortResult, shortVal = 4;
            int integerVal = 67;
            long longResult;
            float floatVal = 10.5F;
            double doubleResult, doubleVal = 99.999;
            string stringResult, stringVal = "17";
            bool boolVal = true;
            WriteLine("Variable Conversion Examples\n");
            doubleResult = floatVal * shortVal;
            WriteLine($"Implicit, -> double: {floatVal} * {shortVal} -> {doubleResult}");
            shortResult = (short) floatVal;
            WriteLine($"Explicit, -> short: {floatVal} -> {shortResult}");
            stringResult = Convert.ToString(boolVal) + Convert.ToString(doubleVal);
            WriteLine($"Explicit, -> string: \"{boolVal}\" + \"{doubleVal}\" -> {stringResult}");
            longResult = integerVal + ToInt64(stringVal);
            WriteLine($"Mixed, -> long: {integerVal} + {stringVal} -> {longResult}");
            ReadKey();
        }
    }
}
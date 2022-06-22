using static System.Console;
using static System.Convert;

namespace Ch04Ex01
{
    /**
     * 使用布尔运算符
     */
    internal class Program
    {
        public static void Main(string[] args)
        {
            WriteLine("Enter an integer:");
            int myInt = ToInt32(ReadLine());
            bool isLessThan10 = myInt < 10;
            bool isBetween0And5 = (0 <= myInt) && (myInt <= 5);
            WriteLine($"Integer less than 10? {isLessThan10}");
            WriteLine($"Integer between 0 and 5? {isBetween0And5}");
            WriteLine($"Exactly one of the above is true? {isLessThan10 ^ isBetween0And5}");
            // 4.2.1 三元运算符
            string resultString = (myInt < 10) ? "Less than 10" : "Greater than or equal to 10";
            WriteLine(resultString);
            ReadKey();
        }
    }
}
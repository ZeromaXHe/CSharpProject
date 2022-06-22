using static System.Console;

namespace Ch05Ex06
{
    /**
     * Visual Studio 中的语句自动完成功能
     */
    internal class Program
    {
        public static void Main(string[] args)
        {
            string myString = "This is a test.";
            char[] separator = {' '};
            string[] myWords;
            myWords = myString.Split(separator);
            foreach (string word in myWords)
            {
                WriteLine($"{word}");
            }

            ReadKey();
        }
    }
}
using static System.Console;

namespace Ch05Ex04
{
    /**
     * 使用数组
     */
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] friendNames = {"Todd Anthony", "Kevin Holton", "Shane Laigle"};
            int i;
            WriteLine($"Here are {friendNames.Length} of my friends:");
            for (i = 0; i < friendNames.Length; i++)
            {
                WriteLine(friendNames[i]);
            }

            // foreach (string friendName in friendNames)
            // {
            //     WriteLine(friendName);
            // }

            ReadKey();
        }
    }
}
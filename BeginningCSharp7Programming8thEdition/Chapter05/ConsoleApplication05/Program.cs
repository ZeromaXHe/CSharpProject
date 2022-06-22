using static System.Console;

namespace ConsoleApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            test5_1_1();
            WriteLine("--------------");
            test5_1_2();
            WriteLine("--------------");
            test5_3();
        }

        /**
         * 5.1.1 隐式转换
         */
        private static void test5_1_1()
        {
            ushort destinationVar;
            char sourceVar = 'a';
            destinationVar = sourceVar;
            WriteLine($"sourceVar val:{sourceVar}");
            WriteLine($"destinationVar val:{destinationVar}");
        }

        /**
         * 5.1.2 显式转换
         */
        private static void test5_1_2()
        {
            byte destinationVar;
            short sourceVar = 7;
            destinationVar = (byte) sourceVar;
            WriteLine($"sourceVar val:{sourceVar}");
            WriteLine($"destinationVar val:{destinationVar}");

            byte destinationVar2;
            short sourceVar2 = 281;
            destinationVar2 = (byte) sourceVar2;
            WriteLine($"sourceVar2 val:{sourceVar2}");
            WriteLine($"destinationVar2 val:{destinationVar2}");
        }

        /**
         * 5.3 字符串的处理
         */
        private static void test5_3()
        {
            string myString = "A string";
            char myChar = myString[1];
            char[] myChars = myString.ToCharArray();
            WriteLine(string.Join(" ", myChars));
            foreach (char character in myString)
            {
                WriteLine($"{character}");
            }

            WriteLine($"myString has {myString.Length} characters.");

            char[] trimChars = {' ', 'e', 's'};
            string userResponse = " userResponses ";
            userResponse = userResponse.ToLower();
            userResponse = userResponse.Trim(trimChars);
            WriteLine(userResponse);

            myString = "Aligned";
            myString = myString.PadLeft(10);
            WriteLine(myString);

            myString = "Aligned";
            myString = myString.PadLeft(10, '-');
            WriteLine(myString);
        }
    }
}
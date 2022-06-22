using System;
using static System.Console;

namespace Ch05Ex02
{
    enum orientation : byte
    {
        north = 1,
        south = 2,
        east = 3,
        west = 4
    }

    /**
     * 使用枚举
     */
    internal class Program
    {
        public static void Main(string[] args)
        {
            byte directionByte;
            string directionString;
            orientation myDirection = orientation.north;
            WriteLine($"myDirection = {myDirection}");
            directionByte = (byte) myDirection;
            directionString = Convert.ToString(myDirection);
            // 和上面等效
            // directionString = myDirection.ToString();
            WriteLine($"byte equivalent = {directionByte}");
            WriteLine($"string equivalent = {directionString}");

            string myString = "south";
            orientation myDirection2 = (orientation) Enum.Parse(typeof(orientation), myString);
            WriteLine(myDirection2);
            ReadKey();
        }
    }
}
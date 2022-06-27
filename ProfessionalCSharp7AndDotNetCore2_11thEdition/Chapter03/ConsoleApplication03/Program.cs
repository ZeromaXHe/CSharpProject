using System;
using System.ComponentModel;

namespace ConsoleApplication03
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            test3_3_1();
            Console.WriteLine("--------------");
            test3_3_2();
            Console.WriteLine("--------------");
            test3_3_3();
            Console.WriteLine("--------------");
            test3_3_4();
            Console.WriteLine("--------------");
            test3_3_5();
            Console.WriteLine("--------------");
            test3_3_6();
            Console.WriteLine("--------------");
            test3_4_1();
            Console.WriteLine("--------------");
            test3_5_1();
            Console.WriteLine("--------------");
            test3_5_2();
            Console.WriteLine("--------------");
            test3_5_3();
            Console.WriteLine("--------------");
            test3_6();
            Console.WriteLine("--------------");
            test3_7();
            Console.WriteLine("--------------");
            test3_9();
        }

        /// <summary>
        /// 3.3.1 字段
        /// </summary>
        private static void test3_3_1()
        {
            var customer1 = new PhoneCustomer();
            customer1.FirstName = "Simon";
            Console.WriteLine(customer1.FirstName);
        }

        /// <summary>
        /// 3.3.2 只读字段
        /// </summary>
        private static void test3_3_2()
        {
            Console.WriteLine(DocumentEditor.s_maxDocuments);
            var document = new Document();
            Console.WriteLine(document._creationTime);
        }

        /// <summary>
        /// 3.3.3 属性
        /// </summary>
        private static void test3_3_3()
        {
            var phoneCustomer2 = new PhoneCustomer2();
            phoneCustomer2.FristName = "test";
            Console.WriteLine(phoneCustomer2.FristName);
            phoneCustomer2.editAgeAndName(18, "name");
            Console.WriteLine(phoneCustomer2.Age);
            Console.WriteLine(phoneCustomer2.Name);
            Console.WriteLine(phoneCustomer2.Id);

            var person = new Person("First", "Last");
            Console.WriteLine(person.FullName);
        }

        /// <summary>
        /// 3.3.4 匿名类型
        /// </summary>
        private static void test3_3_4()
        {
            var captain = new
            {
                FirstName = "James",
                MiddleName = "T",
                LastName = "Kirk"
            };
            var doctor = new
            {
                FirstName = "Leonard",
                MiddleName = string.Empty,
                LastName = "McCoy"
            };
            var captain2 = new
            {
                captain.FirstName,
                captain.MiddleName,
                captain.LastName
            };
            Console.WriteLine(captain.GetType());
            Console.WriteLine(captain2.GetType());
            Console.WriteLine(doctor.GetType());
            Console.WriteLine(captain.GetType() == captain2.GetType());
            Console.WriteLine(captain.GetType() == doctor.GetType());
        }

        /// <summary>
        /// 3.3.5 方法
        /// </summary>
        private static void test3_3_5()
        {
            Console.WriteLine($"Pi is {Math.GetPi()}");
            int x = Math.GetSquareOf(5);
            Console.WriteLine($"Square of 5 is {x}");
            var math = new Math();
            math.Value = 30;
            Console.WriteLine($"Value field of math variable contains {math.Value}");
            Console.WriteLine($"Square of 30 is {math.GetSquare()}");
            // 5. 命名的参数
            Console.WriteLine($"test named param: {math.DoSomething(y: 1, x: 2)}");
            // 6. 可选参数
            math.TestMethod(11);
            math.TestMethod(11, 22);
            math.TestMethod2(1);
            math.TestMethod2(1, 2, 3);
            math.AnyNumberOfArguments(1);
            math.AnyNumberOfArguments(1, 3, 5, 7, 11, 13);
            math.AnyNumberOfArguments("text", 42);
        }

        /// <summary>
        /// 3.3.6 构造函数
        /// </summary>
        private static void test3_3_6()
        {
            Console.WriteLine($"User-preferences: BackColor is: {UserPreferences.BackColor}");
        }

        /// <summary>
        /// 3.4.1 结构是值类型
        /// </summary>
        private static void test3_4_1()
        {
            Dimensions point = new Dimensions(3, 6);
            Console.WriteLine(point.Length);
            Console.WriteLine(point.Width);

            // 书上写这个写法可以，但实际不行？
            // Dimensions point2;
            // point2.Length = 3;
            // point2.Width = 6;
        }

        /// <summary>
        /// 3.5 按值和按引用传递参数
        /// 3.5.1 ref 参数
        /// </summary>
        private static void test3_5_1()
        {
            // 结构按值传递，a1 的内容从不改变，一直是 1
            AStruct a1 = new AStruct {X = 1};
            changeA(a1);
            Console.WriteLine($"a1.X: {a1.X}");
            // 类按引用传递。这里结果是 2
            AClass a2 = new AClass {X = 1};
            changeA(a2);
            Console.WriteLine($"a2.X: {a2.X}");
            // 也可以通过引用传递结构。如果 A 是结构类型，就添加 ref 修饰符，修改 ChangeA 方法的声明，通过引用传递变量
            // 从调用端也可以看出这一点，所以给方法参数应用了 ref 修饰符后，在调用方法时需要添加它
            AStruct a1ref = new AStruct {X = 1};
            changeA(ref a1ref);
            Console.WriteLine($"a1ref.X: {a1ref.X}");
            // 把 A 作为类类型，使用 ref 修饰符，传递对引用的引用（在 C++ 术语中，是一个指向指针的指针），
            // 它允许分配一个新对象，显示结果 3
            AClass a2ref = new AClass {X = 1};
            changeA(ref a2ref);
            Console.WriteLine($"a2ref.X: {a2ref.X}");
        }

        public static void changeA(AStruct a)
        {
            a.X = 2;
        }

        public static void changeA(ref AStruct a)
        {
            a.X = 2;
        }

        public static void changeA(AClass a)
        {
            a.X = 2;
            a = new AClass {X = 3};
        }

        public static void changeA(ref AClass a)
        {
            a.X = 2;
            a = new AClass {X = 3};
        }

        public struct AStruct
        {
            public int X { get; set; }
        }

        public class AClass
        {
            public int X { get; set; }
        }

        /// <summary>
        /// 3.5.2 out 参数
        /// </summary>
        private static void test3_5_2()
        {
            // String input1 = Console.ReadLine();
            // int result1 = int.Parse(input1);
            // Console.WriteLine($"result: {result1}");
            // out var 是 C# 7 的一个新特性。在 C# 7 之前，需要在调用该方法之前声明一个 out 变量。
            // 在 C# 7 中，可以调用方法来实现声明。如果类型是由方法签名明确定义的，则可以使用 var 关键字来声明变量
            String input2 = Console.ReadLine();
            if (int.TryParse(input2, out int result2))
            {
                Console.WriteLine($"result: {result2}");
            }
            else
            {
                Console.WriteLine("not a number");
            }
        }

        /// <summary>
        /// 3.5.3 in 参数
        /// </summary>
        private static void test3_5_3()
        {
            CanChange(new AValueType {Data = 42});
        }

        struct AValueType
        {
            public int Data;
        }

        static void CanChange(in AValueType a)
        {
            // a.Data = 43; // 不能编译 - 只读变量
            Console.WriteLine(a.Data);
        }

        /// <summary>
        /// 3.6 可空类型
        /// </summary>
        private static void test3_6()
        {
            // x1 是一个普通的 int，x2 是一个可以为空的 int
            int x1 = 1;
            int? x2 = null;
            // int 值可以分配给 int?
            int? x3 = x1;
            // 反过来是不正确的。int? 不能直接分配给 int。这可能失败，因此需要一个类型转换
            int x4 = (int) x3;
            Console.WriteLine(x4);
            // 当然，如果 x3 是 null，类型转换操作就会生成一个异常。更好的方法是使用可空类型的 HasValue 和 Value 属性。
            int x5 = x3.HasValue ? x3.Value : -1;
            Console.WriteLine(x5);
            // 使用合并操作符??，可空类型可以使用较短的语法。如果 x3 是 null，则用变量 x6 给它设置 -1，否则提取 x3 的值
            int x6 = x3 ?? -1;
            Console.WriteLine(x6);
        }

        /// <summary>
        /// 3.7 枚举类型
        /// </summary>
        private static void test3_7()
        {
            Color c1 = Color.Red;
            Console.WriteLine(c1);
            Color c2 = (Color) 2;
            Console.WriteLine(c2);
            short number = (short) c2;
            Console.WriteLine(number);
            DaysOfWeek mondayAndWednesday = DaysOfWeek.Monday | DaysOfWeek.Wednesday;
            Console.WriteLine(mondayAndWednesday);
            DaysOfWeek weekend = DaysOfWeek.Saturday | DaysOfWeek.Sunday;
            Console.WriteLine(weekend);
            if (Enum.TryParse<Color>("Red", out var red))
            {
                Console.WriteLine($"successfully parsed {red}");
            }

            foreach (var day in Enum.GetNames(typeof(Color)))
            {
                Console.WriteLine(day);
            }

            foreach (short value in Enum.GetValues(typeof(Color)))
            {
                Console.WriteLine(value);
            }
        }

        public enum Color : short
        {
            Red = 1,
            Green = 2,
            Blue = 3
        }

        // 要设置不同的位，可以使用用 0x 前缀指定的十六进制值轻松完成，Flags 属性是编译器创建值的另一个字符串表示的信息。
        // 例如给 DaysOfWeek 的一个变量设置值 3，结果是 Monday，如果使用 Flags 属性，结果就是 Tuesday
        [Flags]
        public enum DaysOfWeek
        {
            Monday = 0x1,
            Tuesday = 0x2,
            Wednesday = 0x4,
            Thursday = 0x8,
            Friday = 0x10,
            Saturday = 0x20,
            Sunday = 0x40,
            Weekend = Saturday | Sunday,
            Workday = 0x1f,
            AllWeek = Workday | Weekend
        }

        /// <summary>
        /// 3.9 扩展方法
        /// </summary>
        private static void test3_9()
        {
            string fox = "the quick brown fox jumped over the lazy dogs down 9876543210 times";
            int wordCount = fox.GetWordCount();
            Console.WriteLine($"{wordCount} words");
        }
    }

    /// <summary>
    /// 3.3.1 字段
    /// </summary>
    class PhoneCustomer
    {
        public const string DayOfSendingBill = "Monday";
        public int CustomerID;
        public string FirstName;
        public string LastName;
    }

    /// <summary>
    /// 3.3.2 只读字段
    /// </summary>
    public class DocumentEditor
    {
        public static readonly uint s_maxDocuments;

        static DocumentEditor()
        {
            s_maxDocuments = DoSomethingToFindOutMaxNumber();
        }

        private static uint DoSomethingToFindOutMaxNumber()
        {
            return 1;
        }
    }

    /// <summary>
    /// 3.3.2 只读字段
    /// </summary>
    public class Document
    {
        public readonly DateTime _creationTime;

        public Document()
        {
            _creationTime = DateTime.Now;
        }
    }

    /// <summary>
    /// 3.3.3 属性
    /// </summary>
    class PhoneCustomer2
    {
        private string _firstName;

        public string FristName
        {
            // get
            // {
            //     return _firstName;
            // }
            // set
            // {
            //     _firstName = value;
            // }
            get => _firstName;
            set => _firstName = value;
        }

        // private int age;

        public int Age
        {
            // get
            // {
            //     return age;
            // }
            // set
            // {
            //     age = value;
            // }
            get;
            private set;
        } = 42;

        private string _name;

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public void editAgeAndName(int age, string name)
        {
            Name = name;
            Age = age;
        }

        public string Id { get; } = Guid.NewGuid().ToString();
    }

    /// <summary>
    /// 3.3.3 属性
    /// </summary>
    public class Person
    {
        // 自动实现的只读属性
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }

        public string LastName { get; }

        // 从 C# 6 开始，只有 get 访问器的属性可以使用表达式体属性实现。
        public string FullName => $"{FirstName} {LastName}";
    }

    /// <summary>
    /// 3.3.5 方法
    /// </summary>
    public class Math
    {
        public int Value { get; set; }
        public int GetSquare() => Value * Value;
        public static int GetSquareOf(int x) => x * x;
        public static double GetPi() => 3.14159;

        // 4. 方法的重载
        public int DoSomething(int x)
        {
            return DoSomething(x, 10);
        }

        public int DoSomething(int x, int y)
        {
            // implementation
            return x * 1000 + y;
        }

        // 6. 可选参数
        public void TestMethod(int notOptionalNumber, int optionalNumber = 42)
        {
            Console.WriteLine(optionalNumber + notOptionalNumber);
        }

        public void TestMethod2(int n, int opt1 = 11, int opt2 = 22, int opt3 = 33)
        {
            Console.WriteLine(n + opt1 + opt2 + opt3);
        }

        // 7. 个数可变的参数
        public void AnyNumberOfArguments(params int[] data)
        {
            foreach (var x in data)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();
        }

        public void AnyNumberOfArguments(params object[] data)
        {
            foreach (var x in data)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();
        }
    }

    /// <summary>
    /// 3.3.6 构造函数
    /// </summary>
    public class Singleton
    {
        private static Singleton s_instance;
        private int _state;

        private Singleton(int state) => _state = state;

        public static Singleton Instance
        {
            get => s_instance ?? (s_instance = new Singleton(42));
        }
    }

    /// <summary>
    /// 3.3.6 构造函数
    /// 2. 从构造函数中调用其他构造函数
    /// </summary>
    class Car
    {
        private string _description;
        private uint _nWheels;

        public Car(string description, uint nWheels)
        {
            _description = description;
            _nWheels = nWheels;
        }

        public Car(string description) : this(description, 4)
        {
        }
    }

    public enum Color
    {
        White,
        Red,
        Green,
        Blue,
        Black
    }

    /// <summary>
    /// 3.3.6 构造函数
    /// 3. 静态构造函数
    /// </summary>
    public static class UserPreferences
    {
        public static Color BackColor { get; }

        static UserPreferences()
        {
            DateTime now = DateTime.Now;
            if (now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday)
            {
                BackColor = Color.Green;
            }
            else
            {
                BackColor = Color.Red;
            }
        }
    }

    public readonly struct Dimensions
    {
        public double Length { get; }
        public double Width { get; }

        public Dimensions(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public double Diagonal => System.Math.Sqrt(Length * Length + Width * Width);
    }

    /// <summary>
    /// 3.9 扩展方法
    /// </summary>
    public static class StringExtension
    {
        public static int GetWordCount(this string s) => s.Split().Length;
    }
}
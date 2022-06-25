using System;

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
}
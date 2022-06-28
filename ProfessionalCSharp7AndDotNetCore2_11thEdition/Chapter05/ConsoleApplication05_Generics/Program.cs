using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApplication05
{
    /// <summary>
    /// 第 5 章 泛型
    /// </summary>
    internal class Program
    {
        public static void Main(string[] args)
        {
            test5_1_1();
            Console.WriteLine("-------");
            test5_2();
            Console.WriteLine("-------");
            test5_3_2();
            Console.WriteLine("-------");
            test5_4_2();
            Console.WriteLine("-------");
            test5_4_3();
            Console.WriteLine("-------");
            test5_5();
            Console.WriteLine("-------");
            test5_6();
            Console.WriteLine("-------");
            test5_6_1();
            Console.WriteLine("-------");
            test5_6_2();
            Console.WriteLine("-------");
            test5_6_3();
            Console.WriteLine("-------");
            test5_6_4();
        }

        /// <summary>
        /// 5.1.1 性能
        /// </summary>
        private static void test5_1_1()
        {
            var arrayList = new ArrayList();
            arrayList.Add(44); // boxing - convert a value type to a reference type
            int int1 = (int) arrayList[0]; // unboxing - convert a reference type to
            // a value type
            foreach (int i2 in arrayList)
            {
                Console.WriteLine(i2); // unboxing
            }

            var list = new List<int>();
            list.Add(44); // no boxing - value types are stored in the List<int>
            int i1 = list[0]; // no unboxing, no cast needed
            foreach (int i2 in list)
            {
                Console.WriteLine(i2);
            }
        }

        public class LinkedListNode<T>
        {
            public LinkedListNode(T value) => Value = value;

            public T Value { get; }
            public LinkedListNode<T> Next { get; internal set; }
            public LinkedListNode<T> Prev { get; internal set; }
        }

        public class LinkedList<T> : IEnumerable<T>
        {
            public LinkedListNode<T> First { get; private set; }
            public LinkedListNode<T> Last { get; private set; }

            public LinkedListNode<T> AddLast(T node)
            {
                var newNode = new LinkedListNode<T>(node);
                if (First == null)
                {
                    First = newNode;
                    Last = First;
                }
                else
                {
                    LinkedListNode<T> previous = Last;
                    Last.Next = newNode;
                    Last = newNode;
                    Last.Prev = previous;
                }

                return newNode;
            }

            public IEnumerator<T> GetEnumerator()
            {
                LinkedListNode<T> current = First;
                while (current != null)
                {
                    yield return current.Value;
                    current = current.Next;
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        /// <summary>
        /// 5.2 创建泛型类
        /// </summary>
        private static void test5_2()
        {
            var list1 = new LinkedList<int>();
            list1.AddLast(2);
            list1.AddLast(4);
            // list1.AddLast("6");
            foreach (int i in list1)
            {
                Console.WriteLine(i);
            }

            var list2 = new LinkedList<string>();
            list2.AddLast("2");
            list2.AddLast("four");
            list2.AddLast("foo");
            foreach (string s in list2)
            {
                Console.WriteLine(s);
            }
        }

        public class DocumentManager<TDocument> where TDocument : IDocument
        {
            private readonly Queue<TDocument> _documentQueue = new Queue<TDocument>();
            private readonly object _lockQueue = new object();

            public void AddDocument(TDocument doc)
            {
                lock (_lockQueue)
                {
                    _documentQueue.Enqueue(doc);
                }
            }

            public bool IsDocumentAvailable => _documentQueue.Count > 0;

            /// <summary>
            /// 5.3.1 默认值
            /// 通过 default 关键字，将 null 赋予引用类型，将 0 赋予值类型
            /// </summary>
            /// <returns></returns>
            public TDocument GetDocument()
            {
                TDocument doc = default;
                lock (_lockQueue)
                {
                    doc = _documentQueue.Dequeue();
                }

                return doc;
            }

            public void DisplayAllDocuments()
            {
                foreach (TDocument doc in _documentQueue)
                {
                    Console.WriteLine(doc.Title);
                }
            }
        }

        public interface IDocument
        {
            string Title { get; }
            string Content { get; }
        }

        public class Document : IDocument
        {
            public Document(string title, string content)
            {
                Title = title;
                Content = content;
            }

            public string Title { get; }
            public string Content { get; }
        }

        /// <summary>
        /// 5.3.2 约束
        /// </summary>
        private static void test5_3_2()
        {
            var dm = new DocumentManager<Document>();
            dm.AddDocument(new Document("Title A", "Sample A"));
            dm.AddDocument(new Document("Title B", "Sample B"));
            dm.DisplayAllDocuments();
            if (dm.IsDocumentAvailable)
            {
                Document d = dm.GetDocument();
                Console.WriteLine(d.Content);
            }
        }

        public class Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public override string ToString() => $"Width: {Width}, Height: {Height}";
        }

        public class Rectangle : Shape
        {
        }

        public interface IIndex<out T>
        {
            T this[int index] { get; }
            int Count { get; }
        }

        public class RectangleCollection : IIndex<Rectangle>
        {
            private Rectangle[] data = new Rectangle[3]
            {
                new Rectangle {Height = 2, Width = 5},
                new Rectangle {Height = 3, Width = 7},
                new Rectangle {Height = 4.5, Width = 2.9}
            };

            private static RectangleCollection _coll;
            public static RectangleCollection GetRectangles() => _coll ?? (_coll = new RectangleCollection());

            public Rectangle this[int index]
            {
                get
                {
                    if (index < 0 || index > data.Length) throw new ArgumentOutOfRangeException(nameof(index));
                    return data[index];
                }
            }

            public int Count => data.Length;
        }

        /// <summary>
        /// 5.4.2 泛型接口的协变
        /// </summary>
        private static void test5_4_2()
        {
            IIndex<Rectangle> rectangles = RectangleCollection.GetRectangles();
            IIndex<Shape> shapes = rectangles;
            for (int i = 0; i < shapes.Count; i++)
            {
                Console.WriteLine(shapes[i]);
            }
        }

        public interface IDisplay<in T>
        {
            void Show(T item);
        }

        public class ShapeDisplay : IDisplay<Shape>
        {
            public void Show(Shape s) => Console.WriteLine($"{s.GetType().Name} Width: {s.Width}, Height: {s.Height}");
        }

        /// <summary>
        /// 5.4.3 泛型接口的抗变
        /// </summary>
        private static void test5_4_3()
        {
            IDisplay<Shape> shapeDisplay = new ShapeDisplay();
            IDisplay<Rectangle> rectangleDisplay = shapeDisplay;
            rectangleDisplay.Show(RectangleCollection.GetRectangles()[0]);
        }

        /// <summary>
        /// 5.5 范型结构
        /// </summary>
        private static void test5_5()
        {
            Nullable<int> x;
            x = 4;
            x += 3;
            if (x.HasValue)
            {
                int y = x.Value;
            }

            x = null;
            // 因为可空类型使用得非常频繁，所以 C# 有一种特殊的语法，它用于定义可空类型的变量。
            // 定义这类变量时，不使用泛型结构的语法，而使用“?”运算符。
            // 可空类型还可以与算术运算符一起使用。变量 x3 是变量 x1 和 x2 的和。
            // 如果两个可控变量中任何一个的值是 null，它们的和就是 null。
            int? x1 = x;
            int? x2 = 2;
            int? x3 = x1 + x2;
            Console.WriteLine(x3);

            // 非可空类型可以转换为可空类型。从非可空类型转换为可空类型时，在不需要强制类型转换的地方可以进行隐式转换。
            int y1 = 4;
            int? y2 = y1;
            // 但从可空类型转换为非可空类型可能会失败。
            // 如果可空类型的值为 null，并且把 null 值赋予非可空类型，就会抛出 InvalidOperationException 类型的异常。
            int y3 = y2 ?? 0;
            Console.WriteLine(y3);
        }

        static void Swap<T>(ref T x, ref T y)
        {
            T temp;
            temp = x;
            x = y;
            y = temp;
        }

        /// <summary>
        /// 5.6 泛型方法
        /// </summary>
        private static void test5_6()
        {
            int i = 4;
            int j = 5;
            Swap(ref i, ref j);
            Console.WriteLine($"i: {i}, j: {j}");
        }

        public class Account : IAccount
        {
            public string Name { get; }
            public decimal Balance { get; }

            public Account(string name, decimal balance)
            {
                Name = name;
                Balance = balance;
            }
        }

        public static class Algorithms
        {
            // 5.6.1 泛型方法示例
            public static decimal AccumulateSimple(IEnumerable<Account> source)
            {
                decimal sum = 0;
                foreach (Account a in source)
                {
                    sum += a.Balance;
                }

                return sum;
            }

            // 5.6.2 带约束的泛型方法
            public static decimal Accumulate<TAccount>(IEnumerable<TAccount> source) where TAccount : IAccount
            {
                decimal sum = 0;
                foreach (TAccount a in source)
                {
                    sum += a.Balance;
                }

                return sum;
            }

            // 5.6.3 带委托的泛型方法
            public static T2 Accumulate<T1, T2>(IEnumerable<T1> source, Func<T1, T2, T2> action)
            {
                T2 sum = default(T2);
                foreach (T1 item in source)
                {
                    sum = action(item, sum);
                }

                return sum;
            }
        }

        /// <summary>
        /// 5.6.1 泛型方法示例
        /// </summary>
        private static void test5_6_1()
        {
            var accounts = new List<Account>()
            {
                new Account("Christian", 1500),
                new Account("Stephanie", 2200),
                new Account("Angela", 1800),
                new Account("Matthias", 2400),
                new Account("Katharina", 3800)
            };
            decimal amount = Algorithms.AccumulateSimple(accounts);
            Console.WriteLine(amount);
        }

        public interface IAccount
        {
            decimal Balance { get; }
            string Name { get; }
        }

        /// <summary>
        /// 5.6.2 带约束的泛型方法
        /// </summary>
        private static void test5_6_2()
        {
            var accounts = new List<Account>()
            {
                new Account("Christian", 1500),
                new Account("Stephanie", 2200),
                new Account("Angela", 1800),
                new Account("Matthias", 2400),
                new Account("Katharina", 3800)
            };
            decimal amount = Algorithms.Accumulate(accounts);
            Console.WriteLine(amount);
        }

        /// <summary>
        /// 5.6.3 带委托的泛型方法
        /// </summary>
        private static void test5_6_3()
        {
            var accounts = new List<Account>()
            {
                new Account("Christian", 1500),
                new Account("Stephanie", 2200),
                new Account("Angela", 1800),
                new Account("Matthias", 2400),
                new Account("Katharina", 3800)
            };
            decimal amount = Algorithms.Accumulate<Account, decimal>(accounts,
                (item, sum) => sum += item.Balance);
            Console.WriteLine(amount);
        }

        public class MethodOverloads
        {
            public void Foo<T>(T obj) => Console.WriteLine($"Foo<T>(T obj), obj type: {obj.GetType().Name}");
            public void Foo(int x) => Console.WriteLine($"Foo(int x)");

            public void Foo<T1, T2>(T1 obj1, T2 obj2) =>
                Console.WriteLine($"Foo<T1, T2>(T1 obj1, T2 obj2); {obj1.GetType().Name} {obj2.GetType().Name}");

            public void Foo<T>(int obj1, T obj2) =>
                Console.WriteLine($"Foo<T>(int obj1, T obj2); {obj2.GetType().Name}");

            public void Bar<T>(T obj) => Foo(obj);
        }

        private static void test5_6_4()
        {
            var test = new MethodOverloads();
            test.Foo(33);
            test.Foo("abc");
            test.Foo("abc", 42);
            test.Foo(33, "abc");
            // Bar() 方法选择了泛型 Foo() 方法，而不是选择用 int 参数重载的 Foo() 方法。
            // 原因是编译器是在编译期间选择 Bar() 方法调用的 Foo() 方法。
            // 由于 Bar() 方法定义了一个泛型参数，而且泛型 Foo() 方法匹配这个类型，因此调用了 Foo() 方法。
            // 在运行期间给 Bar() 方法传递一个 int 值不会改变这一点。
            test.Bar(44);
        }
    }
}
using System;

namespace ConsoleApplication04
{
    /// <summary>
    /// 第 4 章 继承
    /// </summary>
    internal class Program
    {
        public static void Main(string[] args)
        {
            test4_3_1();
            Console.WriteLine("----------");
            test4_3_2();
            Console.WriteLine("----------");
            test4_3_4();
            Console.WriteLine("----------");
            test4_5_1();
            Console.WriteLine("----------");
            test4_5_2();
        }

        /// <summary>
        /// 4.3.1 虚方法
        /// </summary>
        private static void test4_3_1()
        {
            var r = new Rectangle();
            r.Position.X = 33;
            r.Position.Y = 22;
            r.Size.Width = 200;
            r.Size.Height = 100;
            r.Draw();
        }

        public class Position
        {
            public int X { get; set; }
            public int Y { get; set; }

            public override string ToString() => $"X: {X}, Y: {Y}";
        }

        public class Size
        {
            public int Width { get; set; }
            public int Height { get; set; }

            public override string ToString() => $"Width: {Width}, Height: {Height}";
        }

        public abstract class Shape
        {
            // 4.3.7 派生类的构造函数
            public Shape(int width, int height, int x, int y)
            {
                Size = new Size {Width = width, Height = height};
                Position = new Position {X = x, Y = y};
            }

            public Position Position { get; }

            // 也可以把属性声明为 virtual
            public virtual Size Size { get; }

            // 把一个基类方法声明为 virtual，就可以在任何派生类中重写该方法
            public virtual void Draw() => Console.WriteLine($"Shape with {Position} and {Size}");

            public virtual void Move(Position newPosition)
            {
                Position.X = newPosition.X;
                Position.Y = newPosition.Y;
                Console.WriteLine($"moves to {Position}");
            }

            // 4.3.5 抽象类和抽象方法
            public abstract void Resize(int width, int height);
        }

        public class Rectangle : Shape
        {
            // 4.3.7 派生类的构造函数
            public Rectangle() : base(width: 0, height: 0, x: 0, y: 0)
            {
            }

            public Rectangle(int width, int height, int x, int y) : base(width, height, x, y)
            {
            }


            public override void Draw() => Console.WriteLine($"Rectangle with {Position} and {Size}");

            // 4.3.4 调用方法的基类版本
            public override void Move(Position newPosition)
            {
                Console.Write("Rectangle ");
                base.Move(newPosition);
            }

            public override void Resize(int width, int height)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 4.3.2 多态性
        /// </summary>
        private static void test4_3_2()
        {
            var r = new Rectangle();
            r.Position.X = 33;
            r.Position.Y = 22;
            r.Size.Width = 200;
            r.Size.Height = 100;
            // Rectangle.Draw() 方法而不是 Shape.Draw() 方法的输出
            DrawShape(r);
        }

        public static void DrawShape(Shape shape) => shape.Draw();

        /// <summary>
        /// 4.3.3 隐藏方法
        /// </summary>
        public class Ellipse : Shape
        {
            // 4.3.7 派生类的构造函数
            public Ellipse() : base(width: 0, height: 0, x: 0, y: 0)
            {
            }

            public Ellipse(int width, int height, int x, int y) : base(width, height, x, y)
            {
            }

            // 使用 new 关键字隐藏方法
            // new 方法修饰符不应该故意用于隐藏基类的成员。这个修饰符的主要目的是处理版本冲突，在修改派生类后，响应基类的变化
            new public void Move(int x, int y)
            {
                Position.X += x;
                Position.Y += y;
            }

            public override void Resize(int width, int height)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 4.3.4 调用方法的基类版本
        /// </summary>
        private static void test4_3_4()
        {
            var r = new Rectangle();
            r.Position.X = 33;
            r.Position.Y = 22;
            r.Size.Width = 200;
            r.Size.Height = 100;
            r.Move(new Position {X = 120, Y = 40});
        }

        public interface IDisposable
        {
            void Dispose();
        }

        class SomeClass : IDisposable
        {
            // 这个类必须包含一个 IDisposable.Dispose() 方法的实现，否则会有一个编译错误
            public void Dispose()
            {
            }
        }

        /// <summary>
        /// 4.5.1 定义和实现接口
        /// </summary>
        private static void test4_5_1()
        {
            IBankAccount venusAccount = new SaverAccount();
            IBankAccount jupiterAccount = new GoldAccount();
            venusAccount.PayIn(200);
            venusAccount.Withdraw(100);
            Console.WriteLine(venusAccount.ToString());
            jupiterAccount.PayIn(500);
            jupiterAccount.Withdraw(600);
            jupiterAccount.Withdraw(100);
            Console.WriteLine(jupiterAccount.ToString());
        }

        public interface IBankAccount
        {
            void PayIn(decimal amount);
            bool Withdraw(decimal amount);
            decimal Balance { get; }
        }

        public class SaverAccount : IBankAccount
        {
            private decimal _balance;

            public void PayIn(decimal amount) => _balance += amount;

            public bool Withdraw(decimal amount)
            {
                if (_balance >= amount)
                {
                    _balance -= amount;
                    return true;
                }

                Console.WriteLine("Withdrawal attempt failed.");
                return false;
            }

            public decimal Balance => _balance;

            public override string ToString() => $"Venus Bank Saver: Balance = {_balance,6:C}";
        }

        public class GoldAccount : IBankAccount
        {
            private decimal _balance;

            public void PayIn(decimal amount) => _balance += amount;

            public bool Withdraw(decimal amount)
            {
                if (_balance >= amount)
                {
                    _balance -= amount;
                    return true;
                }

                Console.WriteLine("Withdrawal attempt failed.");
                return false;
            }

            public decimal Balance => _balance;

            public override string ToString() => $"Jupiter Bank Saver: Balance = {_balance,6:C}";
        }

        /// <summary>
        /// 4.5.2 派生的接口
        /// </summary>
        private static void test4_5_2()
        {
            IBankAccount venusAccount = new SaverAccount();
            ITransferBankAccount jupiterAccount = new CurrentAccount();
            venusAccount.PayIn(200);
            jupiterAccount.PayIn(500);
            jupiterAccount.TransferTo(venusAccount, 100);
            Console.WriteLine(venusAccount.ToString());
            Console.WriteLine(jupiterAccount.ToString());
        }

        public interface ITransferBankAccount : IBankAccount
        {
            bool TransferTo(IBankAccount destination, decimal amount);
        }

        public class CurrentAccount : ITransferBankAccount
        {
            private decimal _balance;
            public void PayIn(decimal amount) => _balance += amount;

            public bool Withdraw(decimal amount)
            {
                if (_balance >= amount)
                {
                    _balance -= amount;
                    return true;
                }

                Console.WriteLine("Withdrawal attempt failed.");
                return false;
            }

            public decimal Balance => _balance;

            public bool TransferTo(IBankAccount destination, decimal amount)
            {
                bool result = Withdraw(amount);
                if (result)
                {
                    destination.PayIn(amount);
                }

                return result;
            }

            public override string ToString() => $"Jupiter Bank Current Account: Balance = {_balance,6:C}";
        }
    }
}
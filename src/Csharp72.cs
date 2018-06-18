using System;

namespace Csharp_8
{
    class Csharp72
    {
        #region in

        // The in modifier on parameters, to specify that an argument is passed by reference but not modified by the called method.

        static double CalculateDistance(in Point3D point1, in Point3D point2)
        {
            double xDifference = point1.X - point2.X;
            double yDifference = point1.Y - point2.Y;
            double zDifference = point1.Z - point2.Z;

            return Math.Sqrt(xDifference * xDifference + yDifference * yDifference + zDifference * zDifference);
        }

        #endregion

        #region ref readonly

        // The ref readonly modifier on method returns, to indicate that a method returns its value by reference but doesn't allow writes to that object.

        private static Point3D origin = new Point3D();
        public static ref readonly Point3D Origin => ref origin;

        #endregion

        #region readonly struct

        // The readonly struct declaration, to indicate that a struct is immutable and should be passed as an in parameter to its member methods.

        public readonly struct Person_ReadOnly
        {
            public Person_ReadOnly(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public Person_ReadOnly(Person_ReadOnly other)
            {
                this = other;
            }

            public string Name { get; }
            public int Age { get; }
        }

        #endregion

        #region ref struct

        // The ref struct declaration, to indicate that a struct type accesses managed memory directly and must always be stack allocated.

        #endregion

        #region Named Arguments

        void NamedArguments()
        {
            // Predtým
            PrintOrderDetails("Gift Shop", 31, "Red Mug");

            // Teraz
            PrintOrderDetails(productName: "Red Mug", sellerName: "Gift Shop", orderNum: 31);
        }

        void PrintOrderDetails(string sellerName, int orderNum, string productName)
        {
            Console.WriteLine($"Seller: {sellerName}, Order #: {orderNum}, Product: {productName}");
        }

        #endregion

        #region private protected

        // property 'Text' je viditeľná iba z tried, ktoré dedia z triedy 'Foo' a zároveň sú v rovnakom assembly
        private protected class Foo
        {
            public string Text { get; set; }
        }

        #endregion

        public class Point3D
        {
            public Point3D() { }
            public Point3D(double x, double y, double z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
        }
    }
}

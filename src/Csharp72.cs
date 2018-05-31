using System;

namespace Csharp_8
{
    class Csharp72
    {

        // Reference Semantics With Value Types

        #region in

        static double CalculateDistance(in Point3D point1, in Point3D point2)
        {
            double xDifference = point1.X - point2.X;
            double yDifference = point1.Y - point2.Y;
            double zDifference = point1.Z - point2.Z;

            return Math.Sqrt(xDifference * xDifference + yDifference * yDifference + zDifference * zDifference);
        }

        #endregion

        #region ref readonly

        private static Point3D origin = new Point3D();
        public static ref readonly Point3D Origin => ref origin;

        #endregion

        #region readonly struct

        readonly public struct ReadonlyPoint3D
        {
            public ReadonlyPoint3D(double x, double y, double z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public double X { get; }
            public double Y { get; }
            public double Z { get; }

            private static readonly ReadonlyPoint3D origin = new ReadonlyPoint3D();
            public static ref readonly ReadonlyPoint3D Origin => ref origin;
        }

        #endregion

        #region ref struct

        // vynútená alokácia na stacku

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNeuralNet.Numbers
{
    internal class TriangularNumber
    {
        public double X;
        public double Y;
        public double Z;

        public TriangularNumber() 
        { 
            X = 0;
            Y = 0;
            Z = 0;
        }

        public TriangularNumber(double x, double y, double z)
        {
            X = x; Y = y; Z = z;
        }

        public static TriangularNumber operator +(TriangularNumber a, TriangularNumber b)
        {
            double x = a.X + b.X;
            double y = a.Y + b.Y;
            double z = a.Z + b.Z;

            return new TriangularNumber(x, y, z);
        }

        public static TriangularNumber operator *(TriangularNumber a, TriangularNumber b)
        {
            double x = new double[] { a.X * b.X, a.X * b.Z, a.Z * b.X, a.Z * b.Z }.Min();
            double y = a.Y * b.Y;
            double z = new double[] { a.X * b.X, a.X * b.Z, a.Z * b.X, a.Z * b.Z }.Max();

            return new TriangularNumber(x, y, z);
        }

        public override string ToString()
        {
            return $"({Math.Round(X, 2)},{Math.Round(Y, 2)},{Math.Round(Z, 2)})";
        }
    }
}

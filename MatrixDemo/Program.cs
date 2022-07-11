using System;

namespace MatrixDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] d = new double[2, 2] {{1.0, 2.0}, {3.0, 4.0}}; 
            Console.WriteLine("Hello World!");
            Matrix m = new Matrix(d);
            Console.WriteLine(m.ToString());
        }
    }
}
using System;
using System.Data;
using System.Text;
using VectorDemo;

namespace MatrixDemo
{
    public class Matrix
    {
        private double[,] data;
        public Matrix()
        {
            throw new NotImplementedException();
        }

        public Matrix(int r, int c)
        {
            throw new NotImplementedException();
        }

        public Matrix(double[,] data)
        {
            throw new NotImplementedException();
        }
        
        public double[,] GetArrayRef
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Row
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Col
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public static Matrix operator*(Matrix m1, double c)
        {
            throw new NotImplementedException();
        }
        
        public static Matrix operator*(double c, Matrix m1)
        {
            throw new NotImplementedException();
        }
        
        public static Matrix operator*(Matrix m1, Matrix m2)
        {
            throw new NotImplementedException();
        }
        
        public static Matrix operator+(Matrix m1, Matrix m2)
        {
            throw new NotImplementedException();
        }
        
        public static Matrix operator-(Matrix m1, Matrix m2)
        {
             throw new NotImplementedException();
        }
        
        public static Vector operator*(Matrix m1, Vector v1)
        {
            throw new NotImplementedException();
        }
        
        public static Vector operator*(Vector v1,Matrix m1)
        {
            throw new NotImplementedException();
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Matrix m = (Matrix) obj;
            if (Row != m.Row || Col != m.Col)
                return false;
            for(int i=0;i<Row;++i)
                for(int j=0;j<Col;++j)
                    if (data[i, j] != m.data[i, j])
                        return false;
            return true;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
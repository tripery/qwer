using System;

namespace VectorDemo
{
    public class Vector
    {
        private double[] data;

        public Vector()
        {
            throw new NotImplementedException();
        }
        
        public Vector(int N)
        {
            throw new NotImplementedException();
        }
        
        public Vector(double[] d)
        {
            throw new NotImplementedException();
        }

        public Vector Add(Vector o)
        {
            throw new NotImplementedException();
        }
        
        public Vector Sub(Vector o)
        {
            throw new NotImplementedException();
        }
        
        public double Scalar(Vector o)
        {
            throw new NotImplementedException();
        }
        
        public static Vector operator*(Vector v, double c)
        {
            throw new NotImplementedException();
        }
        
        public static Vector operator*(double c,Vector v)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public int Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        
        public double[] GetArrayRef
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
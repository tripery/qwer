using NUnit.Framework;
using VectorDemo;
using System.Linq;
using System;
using System.Collections.Generic;
using MatrixDemo;

namespace MatrixTestProject
{
    
    public class Tests
    {
        [Test]
        public void Matrix_CostructorDefault_Correct()
        {
            var M = new Matrix();
            bool isSizeCorrect = ((M.Row==3)&&(M.Col==3));
            Assert.True(isSizeCorrect, $"Constructor Matrix() or Row/Col Property dos not work correct\nExpected matrix size: 3*3\nactual size{M.Row}*{M.Col}");
        }

        [TestCaseSource(nameof(CreateMatrix))]
        public void Matrix_DimensionstGet_Correct(double[,] d,(int r, int c) expected)
        {
            var M = new Matrix(d);
            var actualRow = M.Row;
            var actualCol = M.Col;
            Assert.True(actualRow == expected.r&&actualCol == expected.c,$"Properties 'Row' or 'Column'  return incorrect value {actualRow},{actualCol} (expected: {expected.r},{expected.c}");
        }

        [TestCaseSource(nameof(GetDataForMatrixAddition))]
        public void Matrix_Addition_Correct(double[,] a, double[,] b,double[,] expected)
        {
            Matrix A = new Matrix(a), B=new Matrix(b);
            var actual =A+B;
            var Expt = new Matrix(expected);
            Assert.True(actual.Equals(Expt),$"Static operator+ return incorrect value {actual} (expected: {Expt} ");
        }
        
        [TestCaseSource(nameof(GetDataForMatrixSubstrection))]
        public void Matrix_Subtraction_Correct(double[,] a, double[,] b,double[,] expected)
        {
            Matrix A = new Matrix(a), B=new Matrix(b);
            var actual =A-B;
            var Expt = new Matrix(expected);
            Assert.True(actual.Equals(Expt),$"Static operator- return incorrect value {actual} (expected: {Expt} ");
        }
        
        [TestCaseSource(nameof(GetDataForMatrixMultiplication))]
        public void Matrix_OperatorMultiplication_Correct(double[,] a, double[,] b,double[,] expected)
        {
            Matrix A = new Matrix(a), B=new Matrix(b);
            var actual =A*B;
            var Expt = new Matrix(expected);
            Assert.True(actual.Equals(Expt),$"Static operator* return incorrect value {actual.ToString()} (expected: {Expt.ToString()} ");
        }
        
        [TestCaseSource(nameof(GetDataForMatrixConstMultiplication))]
        public void Matrix_OperatorMatrixMultConst_Correct(double[,] a, double b,double[,] expected)
        {
            Matrix A = new Matrix(a);
            var actual =A*b;
            var Expt = new Matrix(expected);
            Assert.True(actual.Equals(Expt),$"Static operator* return incorrect value {actual.ToString()} (expected: {Expt.ToString()} ");
        }
        
        [TestCaseSource(nameof(GetDataForMatrixConstMultiplication))]
        public void Matrix_OperatorConstMultMatrix_Correct(double[,] a, double b,double[,] expected)
        {
            Matrix A = new Matrix(a);
            var actual =b*A;
            var Expt = new Matrix(expected);
            Assert.True(actual.Equals(Expt),$"Static operator* return incorrect value {actual.ToString()} (expected: {Expt.ToString()} ");
        }

        [TestCaseSource(nameof(GetDataForMatrixVectorMultiplication))]
        public void Matrix_OperatorMatrixMultVector_Correct(double[,] a, double[] b,double[] expected)
        {
            Matrix A = new Matrix(a);
            Vector V = new Vector(b);
            var actual =A*V;
            var Expt = new Vector(expected);
            Assert.True(actual.GetArrayRef.SequenceEqual(Expt.GetArrayRef),$"Static operator* return incorrect value {actual.ToString()} (expected: {Expt.ToString()}");
        }
        
        [TestCaseSource(nameof(GetDataForVectorMatrixMultiplication))]
        public void Matrix_OperatorVectorMultMatrix_Correct(double[] b,double[,] a, double[] expected)
        {
            Matrix A = new Matrix(a);
            Vector V = new Vector(b);
            var actual =V*A;
            var Expt = new Vector(expected);
            Assert.True(actual.GetArrayRef.SequenceEqual(Expt.GetArrayRef),$"Static operator* return incorrect value {actual.ToString()} (expected: {Expt.ToString()}");
        }
        
        
        [TestCaseSource(nameof(GetDataForIncorrectOperation))]
        public void Matrix_OperatorMultiplication_Incorect(double[,] a, double[,] b)
        {
            Matrix A = new Matrix(a);
            Matrix B = new Matrix(b);
            var SomeException = Assert.Throws<InvalidOperationException>(() =>{var C=A*B;});
        }
        
        [TestCaseSource(nameof(GetDataForIncorrectOperation))]
        public void Matrix_OperatorAddition_Incorect(double[,] a, double[,] b)
        {
            Matrix A = new Matrix(a);
            Matrix B = new Matrix(b);
            var SomeException = Assert.Throws<InvalidOperationException>(() => {var C=A+B;});
        }
        
        [TestCaseSource(nameof(GetDataForIncorrectOperation))]
        public void Matrix_OperatorSubstraction_Incorect(double[,] a, double[,] b)
        {
            Matrix A = new Matrix(a);
            Matrix B = new Matrix(b);
            var SomeException = Assert.Throws<InvalidOperationException>(() => {var C=A-B;});
        }


        private static IEnumerable<object[]> CreateMatrix()
        {
            yield return new object[]
            {
                new double[2, 2] {{1.0, 0.0}, {0.0, 1.0}},
                (2, 2)
            };
            yield return new object[]
            {
                new double[2, 4] {{1.0, 0.0,3.4,5.5}, {0.0,1.0,6.7,9.9}},
                (2, 4)
            };
            yield return new object[]
            {
                new double[3,3] {{1.0, 0.0,0.0}, {0.0, 1.0,0.0},{0.0,0.0,1.0}},
                (3, 3)
            };
            yield return new object[]
            {
                new double[1, 4],
                (1, 4)
            };
            yield return new object[]
            {
                new double[4, 4],
                (4, 4)
            };
        }

        private static IEnumerable<object[]> GetDataForMatrixAddition()
        {
            yield return new object[]
            {
                new double[2, 2] {{1.0, 2.0}, {3.0, 4.0}},
                new double[2, 2] {{4.0, 3.0}, {2.0, 1.0}},
                new double[2, 2] {{5.0, 5.0}, {5.0, 5.0}}
            };
            yield return new object[]
            {
                new double[2, 4] {{1.0, 0.0,3.0,5.0},  {0.0,1.0,6.0,9.0}},
                new double[2, 4] {{5.0, 5.0,5.0,5.0},  {5.0,5.0,5.0,5.0}},
                new double[2, 4] {{6.0, 5.0,8.0,10.0}, {5.0,6.0,11.0,14.0}}
            };
            yield return new object[]
            {
                new double[3,3] {{10.0, 7.0, 8.0}, { 9.0, 20.0, -7.0}, {15.0, 15.0, 15.0}},
                new double[3,3] {{ 5.0, 8.0, 7.0}, { 6.0, -5.0, 22.0}, { 0.0,  0.0,  0.0}},
                new double[3,3] {{15.0,15.0,15.0}, {15.0, 15.0, 15.0}, {15.0, 15.0, 15.0}}
            };
        }

        private static IEnumerable<object[]> GetDataForMatrixSubstrection()
        {
            yield return new object[]
            {
                new double[2, 2] {{1.0, 2.0},   {3.0, 4.0}},
                new double[2, 2] {{4.0, 3.0},   {2.0, 1.0}},
                new double[2, 2] {{-3.0, -1.0}, {1.0, 3.0}}
            };
            yield return new object[]
            {
                new double[2, 4] {{ 1.0, 0.0, 3.0, 5.0},  { 0.0, 1.0,6.0,9.0}},
                new double[2, 4] {{ 5.0, 5.0, 5.0, 5.0},  { 5.0, 5.0,5.0,5.0}},
                new double[2, 4] {{-4.0,-5.0,-2.0, 0.0},  {-5.0,-4.0,1.0,4.0}}
            };
            yield return new object[]
            {
                new double[3,3] {{10.0, 7.0, 8.0}, { 9.0, 20.0, -7.0}, {15.0, 15.0, 15.0}},
                new double[3,3] {{ 5.0, 8.0, 7.0}, { 6.0, -5.0, 22.0}, { 0.0,  0.0,  0.0}},
                new double[3,3] {{ 5.0,-1.0, 1.0}, { 3.0, 25.0,-29.0}, {15.0, 15.0, 15.0}}
            };
        }

        private static IEnumerable<object[]> GetDataForMatrixMultiplication()
        {
            yield return new object[]
            {
                new double[2, 2] {{1.0, 2.0},
                                  {3.0, 4.0}},
                new double[2, 2] {{4.0, 3.0},
                                  {2.0, 1.0}},
                new double[2, 2] {{ 8.0, 5.0},
                                  {20.0,13.0}}
            };
            yield return new object[]
            {
                new double[2, 4] {{1.0, 0.0,3.0,5.0},
                                  {0.0,1.0,6.0,9.0}},
                new double[4, 2] {{5.0, 5.0},
                                  {5.0, 5.0},
                                  {5.0, 5.0},
                                  {5.0, 5.0}},
                new double[2, 2] {{45.0, 45.0},
                                  {80.0, 80.0}}
            };
            yield return new object[]
            {
                new double[3,3] {{ 1.0,  2.0,  3.0},
                                 { 4.0,  5.0,  6.0},
                                 { 7.0,  8.0,  9.0}},
                new double[3,3] {{ 9.0, 8.0, 7.0},
                                 { 6.0, 5.0, 4.0},
                                 { 3.0, 2.0, 1.0}},
                new double[3,3] {{30.0,   24.0, 18.0},
                                 {84.0,   69.0, 54.0},
                                 {138.0, 114.0, 90.0}}
            };
        }

        private static IEnumerable<object[]> GetDataForMatrixConstMultiplication()
        {
            yield return new object[]
            {
                new double[2, 2] {{1.0, 2.0},
                                  {3.0, 4.0}},
                4,
                new double[2, 2] {{ 4.0, 8.0},
                                  { 12.0,16.0}}
            };
            yield return new object[]
            {
                new double[2, 4] {{1.0, 0.0, 3.0, 5.0},
                                  {0.0, 1.0, 6.0, 9.0}},
                5,
                new double[2, 4] {{5.0, 0.0,15.0,25.0},
                                  {0.0, 5.0,30.0,45.0}}
            };
        }

        private static IEnumerable<object[]> GetDataForMatrixVectorMultiplication()
        {
            yield return new object[]
            {
                new double[2, 2] {{1.0, 2.0},
                                  {3.0, 4.0}},
                new double[]{1.0, 2.0},
                new double[] { 5.0, 11.0}
            };
            yield return new object[]
            {
                new double[2, 4] {{1.0, 0.0, 3.0, 5.0},
                                  {0.0, 1.0, 6.0, 9.0}},
                new double[]{1.0, 2.0, 3.0, 4.0},
                new double[]{30,56}
            };
        }

        private static IEnumerable<object[]> GetDataForVectorMatrixMultiplication()
        {
            yield return new object[]
            {
                new double[]{1.0, 2.0},
                new double[2, 2] {{1.0, 2.0},
                                  {3.0, 4.0}},
                new double[] { 7.0, 10.0}
            };
            yield return new object[]
            {
                new double[]{3.0, 4.0},
                new double[2, 4] {{1.0, 0.0, 3.0, 5.0},
                                  {0.0, 1.0, 6.0, 9.0}},
                new double[]{3,4,33,51}
            };
        }

        private static IEnumerable<object[]> GetDataForIncorrectOperation()
        {
            yield return new object[]
            {
                new double[3,3],
                new double[2,3]
            };
            yield return new object[]
            {
                new double[4,5],
                new double[3,4]
            };
            yield return new object[]
            {
                new double[4,5],
                new double[4,4]
            };
            yield return new object[]
            {
                new double[6,4],
                new double[5,5]
            };
            yield return new object[]
            {
                new double[4,4],
                new double[5,5]
            };
        }

    }
}
using NUnit.Framework;
using VectorDemo;
using System.Linq;
using System;

namespace VecorTestProject
{
    public class Tests
    {
        [Test]
        public void Vector_CostructorDefault_Correct()
        {
            var V = new Vector();
            int actualSize = V.Length;
            Assert.True(actualSize==3, $"Constructor Vector() or Length Property dos not work correct");
        }
        [TestCase(new double[] {1.0, 0.0, 0.0})]
        [TestCase(new double[] {1.0, 0.0, 0.0})]
        [TestCase(new double[] {1.0, 2.0, 3.0})]
        public void Vector_CostructorFromArrayAndArrayGetRef_Correct(double[] v1)
        {
            var V = new Vector(v1);
            var actualResult = V.GetArrayRef;
            Assert.True(actualResult.SequenceEqual(v1), message: $"Constructor Vector(double[] ) or GetArrayRef Property dos not work correct");
        }

        [TestCase(new double[] {1.0, 0.0, 0.0},3)]
        [TestCase(new double[] {1.0, 0.0, 1.0,0.0},4)]
        [TestCase(new double[] {1.0, 2.0, 3.0,4.0,5.0},5)]
        public void Vector_CountGet_Correct(double[] v1,int expected)
        {
            var V = new Vector(v1);
            var actualResult = V.Length;
            Assert.True(actualResult==expected,message: $"Properties 'Count'  return incorrect value {actualResult} (expected: {expected})");
        }

        [TestCase(new double[] {1.0, 0.0, 0.0},"(1;0;0)")]
        [TestCase(new double[] {1.0, 0.0, 1.0,0.0},"(1;0;1;0)")]
        [TestCase(new double[] {1.0, 2.0, 3.0,4.0,5.0},"(1;2;3;4;5)")]
        public void Vector_ToString_Correct(double[] v1,string expected)
        {
            var V = new Vector(v1);
            var actualResult = V.ToString();
            Assert.True(actualResult == expected,$"Method 'ToString()'  does not work properly. Returned {actualResult} (Expected: {expected})");
        }
        
        
        [TestCase(new double[]{1.0,0.0,0.0}, new double[]{1.0,0.0,0.0}, 1.0)]
        [TestCase(new double[]{1.0,0.0,0.0}, new double[]{0.0,1.0,0.0}, 0.0)]
        [TestCase(new double[]{1.0,2.0,3.0}, new double[]{10.0,20.0,30.0}, 140.0)]
        public void Vector_ScalarValue_Correct(double[] v1,double[] v2, double expected)
        {
            var V1 = new VectorDemo.Vector(v1);
            var V2 = new VectorDemo.Vector(v2);
            var actualResult = V1.Scalar(V2);
            Assert.True(actualResult == expected,$"Method 'Scalar'  return incorrect value {actualResult} (expected: {expected})");
        }
        
        [TestCase(new double[]{1.0,0.0,0.0}, new double[]{1.0,0.0,0.0}, new double[]{2.0,0.0,0.0})]
        [TestCase(new double[]{1.0,0.0,0.0}, new double[]{0.0,1.0,0.0}, new double[]{1.0,1.0,0.0})]
        [TestCase(new double[]{1.0,2.0,3.0}, new double[]{10.0,20.0,30.0}, new double[]{11.0,22.0,33.0})]
        [TestCase(new double[]{-1.0,2.0},    new double[]{10.0,-20.0},  new double[]{9.0,-18.0})]
        [TestCase(new double[]{1.0,2.0,3.0,4.0}, new double[]{-10.0,20.0,-30.0,40.0}, new double[]{-9.0,22.0,-27.0,44.0})]
        public void Vector_AdditionMethod_Correct(double[] v1,double[] v2, double[] expected)
        {
            var V1 = new VectorDemo.Vector(v1);
            var V2 = new VectorDemo.Vector(v2);
            var actualResult = V1.Add(V2);
            Assert.True(expected.SequenceEqual(actualResult.GetArrayRef),$"Method 'Add'  return incorrect value actualResult (expected: expected)");
        }
 
        [TestCase(new double[]{1.0,0.0,0.0}, new double[]{1.0,0.0,0.0}, new double[]{0.0,0.0,0.0})]
        [TestCase(new double[]{1.0,0.0,0.0}, new double[]{0.0,1.0,0.0}, new double[]{1.0,-1.0,0.0})]
        [TestCase(new double[]{1.0,2.0,3.0}, new double[]{10.0,20.0,30.0}, new double[]{-9.0,-18.0,-27.0})]
        [TestCase(new double[]{-1.0,2.0},    new double[]{10.0,-20.0},  new double[]{-11.0,22.0})]
        [TestCase(new double[]{1.0,2.0,3.0,4.0}, new double[]{-10.0,20.0,-30.0,40.0}, new double[]{11.0,-18.0,33.0,-36.0})]
        public void Vector_SubtructionMethod_Correct(double[] v1,double[] v2, double[] expected)
        {
            var V1 = new VectorDemo.Vector(v1);
            var V2 = new VectorDemo.Vector(v2);
            var actualResult = V1.Sub(V2);
            Assert.True(expected.SequenceEqual(actualResult.GetArrayRef),message: $"Method 'Sub'  return incorrect value actualResult (expected: expected)");
        }
        
        [TestCase(new double[]{1.0,0.0,0.0}, 1, new double[]{1.0,0.0,0.0})]
        [TestCase(new double[]{1.0,0.0,0.0}, 2, new double[]{2.0,0.0,0.0})]
        [TestCase(new double[]{1.0,2.0,3.0}, 3, new double[]{3.0,6.0,9.0})]
        [TestCase(new double[]{1.0,2.0,3.0}, -1, new double[]{-1.0,-2.0,-3.0})]
        [TestCase(new double[]{1.0,2.0,3.0}, 0, new double[]{0.0,0.0,0.0})]
        [TestCase(new double[]{1.0,2.0,3.0}, -10, new double[]{-10.0,-20.0,-30.0})]
        public void Vector_OperatorVectorMultConst_Correct(double[] v1,double c, double[] expected)
        {
            var V1 = new VectorDemo.Vector(v1);
            var actualResult = V1*c;
            Assert.True(expected.SequenceEqual(actualResult.GetArrayRef), $"Method 'Scalar'  return incorrect value {actualResult} (expected: {expected})");
        }

        [TestCase(new double[]{1.0,0.0,0.0}, 1, new double[]{1.0,0.0,0.0})]
        [TestCase(new double[]{1.0,0.0,0.0}, 2, new double[]{2.0,0.0,0.0})]
        [TestCase(new double[]{1.0,2.0,3.0}, 3, new double[]{3.0,6.0,9.0})]
        [TestCase(new double[]{1.0,2.0,3.0}, -1, new double[]{-1.0,-2.0,-3.0})]
        [TestCase(new double[]{1.0,2.0,3.0}, 0, new double[]{0.0,0.0,0.0})]
        [TestCase(new double[]{1.0,2.0,3.0}, -10, new double[]{-10.0,-20.0,-30.0})]
        public void Vector_OperatorConstMultVector_Correct(double[] v1,double c, double[] expected)
        {
            var V1 = new VectorDemo.Vector(v1);
            var actualResult = c*V1;
            Assert.True(expected.SequenceEqual(actualResult.GetArrayRef),$"Method 'Scalar'  return incorrect value {actualResult} (expected: {expected})");
        }
        
        
        [TestCase(new double[]{1.0,0.0}, new double[]{1.0,0.0,0.0})]
        [TestCase(new double[]{1.0,0.0,0.0}, new double[]{0.0,1.0,0.0,4.4})]
        [TestCase(new double[]{1.0,2.0,3.0,6.6}, new double[]{10.0,20.0,30.0,7.7,8.8})]
        public void Vector_ScalarValue_Incorrect(double[] v1,double[] v2)
        {
            var V1 = new VectorDemo.Vector(v1);
            var V2 = new VectorDemo.Vector(v2);
            var SomeException = Assert.Throws<InvalidOperationException>(() => V1.Scalar(V2),"");
        }
        
        [TestCase(new double[]{1.0,0.0}, new double[]{1.0,0.0,0.0})]
        [TestCase(new double[]{1.0,0.0,0.0}, new double[]{0.0,1.0,0.0,4.4})]
        [TestCase(new double[]{1.0,2.0,3.0,6.6}, new double[]{10.0,20.0,30.0,7.7,8.8})]
        public void Vector_Addition_Incorrect(double[] v1,double[] v2)
        {
            var V1 = new VectorDemo.Vector(v1);
            var V2 = new VectorDemo.Vector(v2);
            var SomeException = Assert.Throws<InvalidOperationException>(() => V1.Add(V2));
        }
 
        [TestCase(new double[]{1.0,0.0}, new double[]{1.0,0.0,0.0})]
        [TestCase(new double[]{1.0,0.0,0.0}, new double[]{0.0,1.0,0.0,4.4})]
        [TestCase(new double[]{1.0,2.0,3.0,6.6}, new double[]{10.0,20.0,30.0,7.7,8.8})]
        public void Vector_Subtruction_Incorrect(double[] v1,double[] v2)
        {
            var V1 = new VectorDemo.Vector(v1);
            var V2 = new VectorDemo.Vector(v2);
            var SomeException = Assert.Throws<InvalidOperationException>(() => V1.Sub(V2));
        }
        
/*        [SetUp]
        public void Setup()
        {
        
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }*/
    }
}
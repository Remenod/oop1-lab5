using System;
using System.Numerics;
using lab5.MyNumber;

namespace Lab5.Tests
{
    [TestClass]
    public class MyFracTests
    {
        [TestMethod]
        public void Constructor_SimplifiesFraction()
        {
            var frac = new MyFrac(2, 4);

            Assert.AreEqual(new BigInteger(1), frac.Nom);
            Assert.AreEqual(new BigInteger(2), frac.Denom);
            Assert.AreEqual("1/2", frac.ToString());
        }

        [TestMethod]
        public void Constructor_HandlesNegativeDenominator()
        {
            var frac = new MyFrac(1, -2);

            Assert.AreEqual(new BigInteger(-1), frac.Nom);
            Assert.AreEqual(new BigInteger(2), frac.Denom);
        }

        [TestMethod]
        public void Constructor_ThrowsOnZeroDenominator()
        {
            try
            {
                new MyFrac(1, 0);
                Assert.Fail("A DivideByZeroException error was expected, but it did not occur.");
            }
            catch (DivideByZeroException) { }
            catch (Exception ex)
            {
                Assert.Fail($"DivideByZeroException was expected, but {ex.GetType().Name} was received");
            }
        }

        [TestMethod]
        public void Add_CalculatesCorrectly()
        {
            var f1 = new MyFrac(1, 2);
            var f2 = new MyFrac(1, 3);

            var result = f1.Add(f2);

            Assert.AreEqual("5/6", result.ToString());
        }

        [TestMethod]
        public void Divide_CalculatesCorrectly()
        {
            var f1 = new MyFrac(1, 2);
            var f2 = new MyFrac(3, 4);

            var result = f1.Divide(f2);

            Assert.AreEqual("2/3", result.ToString());
        }

        [TestMethod]
        public void Divide_ThrowsWhenDividingByZeroFraction()
        {
            var f1 = new MyFrac(1, 2);
            var f2 = new MyFrac(0, 5);

            try
            {
                f1.Divide(f2);
                Assert.Fail("A DivideByZeroException error was expected when dividing by a zero fraction.");
            }
            catch (DivideByZeroException) { }
            catch (Exception ex)
            {
                Assert.Fail($"DivideByZeroException was expected, but {ex.GetType().Name} was received");
            }
        }

        [TestMethod]
        public void Parse_ValidString_CreatesFrac()
        {
            var frac = new MyFrac("-10 / 20");
            Assert.AreEqual("-1/2", frac.ToString());
        }

        [TestMethod]
        public void CompareTo_SortsCorrectly()
        {
            var f1 = new MyFrac(1, 2); // 0.5
            var f2 = new MyFrac(1, 3); // 0.33...

            Assert.IsTrue(f1.CompareTo(f2) > 0, "1/2 must be greater than 1/3");
        }
    }

    [TestClass]
    public class MyComplexTests
    {
        [TestMethod]
        public void Add_CalculatesCorrectly()
        {
            var c1 = new MyComplex(1, 2);
            var c2 = new MyComplex(3, 4);

            var res = c1.Add(c2);

            Assert.AreEqual(4, res.Real);
            Assert.AreEqual(6, res.Imag);
        }

        [TestMethod]
        public void Multiply_CalculatesCorrectly()
        {
            var c1 = new MyComplex(1, 2);
            var c2 = new MyComplex(3, 4);

            var res = c1.Multiply(c2);

            Assert.AreEqual(-5, res.Real);
            Assert.AreEqual(10, res.Imag);
        }

        [TestMethod]
        public void ToString_FormatsCorrectly()
        {
            var c1 = new MyComplex(1, -5);
            Assert.AreEqual("1 - 5i", c1.ToString());

            var c2 = new MyComplex(1, 5);
            Assert.AreEqual("1 + 5i", c2.ToString());
        }

        [TestMethod]
        public void Parse_ValidString_CreatesComplex()
        {
            var c = new MyComplex("5 + 10i");
            Assert.AreEqual(5, c.Real);
            Assert.AreEqual(10, c.Imag);

            var c2 = new MyComplex("5 - 10i");
            Assert.AreEqual(5, c2.Real);
            Assert.AreEqual(-10, c2.Imag);
        }

        [TestMethod]
        public void Parse_InvalidString_Throws()
        {
            try
            {
                new MyComplex("not a number");
                Assert.Fail("An ArgumentException error was expected.");
            }
            catch (ArgumentException) { }
            catch (Exception ex)
            {
                Assert.Fail($"ArgumentException was expected, but {ex.GetType().Name} was received");
            }
        }
    }
}
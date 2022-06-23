using static SharpFractions.BigIntExtra;

namespace SharpFractionsTest;


[TestClass]
public class BigIntExtraTest
{
    [TestMethod]
    public void LeastCommonMultiple_Both0_ThrowsArgumentException()
    {
        BigInteger first = 0;
        BigInteger second = 0;

        Assert.ThrowsException<ArgumentException>(() => LeastCommonMultiple(first, second));
    }

    [TestMethod]
    public void LeastCommonMultiple_First0_Equals0()
    {
        BigInteger first = 1;
        BigInteger second = 0;

        BigInteger lcm = LeastCommonMultiple(first, second);

        Assert.AreEqual(lcm, BigInteger.Zero);
    }

    [TestMethod]
    public void LeastCommonMultiple_Second0_Equals0()
    {
        BigInteger first = 0;
        BigInteger second = 1;

        BigInteger lcm = LeastCommonMultiple(first, second);

        Assert.AreEqual(lcm, BigInteger.Zero);
    }

    [TestMethod]
    public void LeastCommonMultiple_Of1and1_Return1()
    {
        BigInteger first = 1;
        BigInteger second = 1;

        BigInteger lcm = LeastCommonMultiple(first, second);

        Assert.AreEqual(lcm, BigInteger.One);
    }

    [TestMethod]
    public void LeastCommonMultiple_Of11and1_Return11()
    {
        BigInteger first = 11;
        BigInteger second = 1;

        BigInteger lcm = LeastCommonMultiple(first, second);

        Assert.AreEqual(first, lcm);
    }

    [TestMethod]
    public void LeastCommonMultiple_Of1and15_Return15()
    {
        BigInteger first = 1;
        BigInteger second = 15;

        BigInteger lcm = LeastCommonMultiple(first, second);

        Assert.AreEqual(second, lcm);
    }

    [TestMethod]
    public void LeastCommonMultiple_Of4and6_Return12()
    {
        BigInteger first = 4;
        BigInteger second = 6;

        BigInteger result = 12;

        BigInteger lcm = LeastCommonMultiple(first, second);

        Assert.AreEqual(result, lcm);
    }

    [TestMethod]
    public void LeastCommonMultiple_Of21and6_Return42()
    {
        BigInteger first = 21;
        BigInteger second = 6;

        BigInteger result = 42;

        BigInteger lcm = LeastCommonMultiple(first, second);

        Assert.AreEqual(result, lcm);
    }

    [TestMethod]
    public void LeastCommonMultiple_Of48and180_Return720()
    {
        BigInteger first = 48;
        BigInteger second = 180;

        BigInteger result = 720;

        BigInteger lcm = LeastCommonMultiple(first, second);

        Assert.AreEqual(result, lcm);
    }

    [TestMethod]
    public void LeastCommonMultiple_OfNeg1andNeg1_Return1()
    {
        BigInteger first = -1;
        BigInteger second = -1;

        BigInteger result = 1;

        BigInteger lcm = LeastCommonMultiple(first, second);

        Assert.AreEqual(result, lcm);
    }

    [TestMethod]
    public void LeastCommonMultiple_OfNeg1and11_Return11()
    {
        BigInteger first = -1;
        BigInteger second = 11;

        BigInteger result = 11;

        BigInteger lcm = LeastCommonMultiple(first, second);

        Assert.AreEqual(result, lcm);
    }

    [TestMethod]
    public void LeastCommonMultiple_OfNeg1andNeg11_Return11()
    {
        BigInteger first = -1;
        BigInteger second = -11;

        BigInteger result = 11;

        BigInteger lcm = LeastCommonMultiple(first, second);

        Assert.AreEqual(result, lcm);
    }

    [TestMethod]
    public void LeastCommonMultiple_OfNeg48andNeg180_Return720()
    {
        BigInteger first = -48;
        BigInteger second = -180;

        BigInteger result = 720;

        BigInteger lcm = LeastCommonMultiple(first, second);

        Assert.AreEqual(result, lcm);
    }
}
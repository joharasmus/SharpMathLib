namespace SharpFractionsTest;

[TestClass]
public class OperatorsTest
{
    [TestMethod]
    public void UnaryPlus_Neg5Over2_ReturnSame()
    {
        Fraction real = new(-5, 2);
        real = +real;

        Fraction expcted = new(-5, 2);

        Assert.AreEqual(expcted, real);
    }

    [TestMethod]
    public void BinaryPlus_3Over4Plus4Over3_Return25Over12()
    {
        Fraction frac1 = new(3, 4);
        Fraction frac2 = new(4, 3);

        Fraction sum = frac1 + frac2;

        Fraction expected = new(25, 12);

        Assert.AreEqual(expected, sum);
    }

    [TestMethod]
    public void UnaryMinus_Neg5Over2_Return5Over2()
    {
        Fraction real = new(-5, 2);
        real = -real;

        Fraction expcted = new(5, 2);

        Assert.AreEqual(expcted, real);
    }

    [TestMethod]
    public void Multiply_Neg5Over2And3Over4_ReturnNeg15Over8()
    {
        Fraction frac1 = new(-5, 2);
        Fraction frac2 = new(3, 4);

        Fraction real = frac1 * frac2;

        Fraction expcted = new(-15, 8);

        Assert.AreEqual(expcted, real);
    }

    [TestMethod]
    public void BinaryDivision_3Over4DividedBy4Over3_Equals9Over16()
    {
        Fraction frac1 = new(3, 4);
        Fraction frac2 = new(4, 3);

        Fraction quot = frac1 / frac2;

        Fraction expected = new(9, 16);

        Assert.AreEqual(expected, quot);
    }
}

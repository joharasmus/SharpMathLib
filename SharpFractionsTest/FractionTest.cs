

namespace SharpFractionsTest;

[TestClass]
public class FractionTest
{
    [TestMethod]
    public void Ctor_Denom0_ThrowsDivideByZeroException()
    {
        BigInteger num = 5;
        BigInteger den = 0;

        Assert.ThrowsException<DivideByZeroException>(() => new Fraction(num, den));
    }

    [TestMethod]
    public void Ctor_Num1Denom2_CorrectProperties()
    {
        BigInteger num = 1;
        BigInteger den = 2;

        Fraction fraction = new(num, den);

        Assert.AreEqual(num, fraction.Numerator);
        Assert.AreEqual(den, fraction.Denominator);
    }

    [TestMethod]
    public void Ctor_SingleArgument_FracWithDenom1()
    {
        BigInteger bigInteger = 3;

        Fraction fraction = new(bigInteger);

        Assert.AreEqual(bigInteger, fraction.Numerator);
        Assert.AreEqual(BigInteger.One, fraction.Denominator);
    }

    [TestMethod]
    public void IsInt_ActualInt_ReturnsTrue()
    {
        Fraction fraction = new(10, 2);

        Assert.IsTrue(fraction.IsInt);
    }

    [TestMethod]
    public void IsInt_NotAnInt_ReturnsFalse()
    {
        Fraction fraction = new(11, 4);

        Assert.IsFalse(fraction.IsInt);
    }

    [TestMethod]
    public void IsZero_ZeroNumerator_ReturnsTrue()
    {
        Fraction fraction = new(0, 3);

        Assert.IsTrue(fraction.IsZero);
    }

    [TestMethod]
    public void IsZero_NonZeroNumerator_ReturnsFalse()
    {
        Fraction fraction = new(5, 4);

        Assert.IsFalse(fraction.IsZero);
    }

    [TestMethod]
    public void IsOne_NumEqualsDenom_ReturnsTrue()
    {
        Fraction fraction = new(3, 3);

        Assert.IsTrue(fraction.IsOne);
    }

    [TestMethod]
    public void IsOne_NumDoesNotEqualDenom_ReturnsFalse()
    {
        Fraction fraction = new(7, 4);

        Assert.IsFalse(fraction.IsOne);
    }

    [TestMethod]
    public void Sign_ZeroFraction_Returns0()
    {
        Fraction fraction = new(0, 3);

        Assert.AreEqual(0, fraction.Sign);
    }

    [TestMethod]
    public void Sign_NegativeFraction_ReturnsNeg1()
    {
        Fraction fraction = new(-5, 7);

        Assert.AreEqual(-1, fraction.Sign);
    }

    [TestMethod]
    public void Sign_PositiveFraction_ReturnsPos1()
    {
        Fraction fraction = new (11, 3);

        Assert.AreEqual(1, fraction.Sign);
    }

    [TestMethod]
    public void Whole_Num5Den2_Returns2()
    {
        Fraction fraction = new(5, 2);

        Assert.AreEqual(2, fraction.Whole);
    }

    [TestMethod]
    public void Part_Num8Den3_Returns2()
    {
        Fraction fraction = new(8, 3);

        Assert.AreEqual(2, fraction.Part);
    }

    [TestMethod]
    public void Mixed_Num11Den5_ReturnsCorrect()
    {
        Fraction fraction = new(11, 5);

        BigInteger realWhole = 2;

        BigInteger partNum = 1;
        BigInteger partDenom = 5;

        (BigInteger whole, Fraction part) = fraction.Mixed;

        Assert.AreEqual(realWhole, whole);
        Assert.AreEqual(partNum, part.Numerator);
        Assert.AreEqual(partDenom, part.Denominator);
    }
}

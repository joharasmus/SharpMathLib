

using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace SharpFractionsTest;

[TestClass]
public class FractionTest
{
    [TestMethod]
    public void Ctor_Denom0_ThrowsDivideByZeroException()
    {
        BigInteger num = 5;
        BigInteger den = 0;

        Assert.ThrowsExactly<DivideByZeroException>(() => new Fraction(num, den));
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

    [TestMethod]
    public void MinusOne_GetMinusOne_ReturnsCorrect()
    {
        Fraction fraction = Fraction.MinusOne;

        Fraction expected = new(-1);

        Assert.AreEqual(expected, fraction);
    }

    [TestMethod]
    public void One_GetOne_ReturnsCorrect()
    {
        Fraction fraction = Fraction.One;

        Fraction expected = new(1);

        Assert.AreEqual(expected, fraction);
    }

    [TestMethod]
    public void Zero_GetZero_ReturnsCorrect()
    {
        Fraction fraction = Fraction.Zero;

        Fraction expected = new(0);

        Assert.AreEqual(expected, fraction);
    }

    [TestMethod]
    public void ExpandBy_Expand3over4By5_Expect15over20()
    {
        Fraction frac = new(3, 4);

        frac = frac.ExpandBy(5);

        Fraction real = new(15, 20);

        Assert.AreEqual(frac.Numerator, real.Numerator);
        Assert.AreEqual(frac.Denominator, real.Denominator);
    }

    [TestMethod]
    public void Invert_3Over2_2Over3()
    {
        Fraction fraction = new(3, 2);

        fraction = fraction.Invert();

        Fraction real = new(2, 3);

        Assert.AreEqual(real.Numerator, fraction.Numerator);
        Assert.AreEqual(real.Denominator, fraction.Denominator);
    }

    [TestMethod]
    public void Invert_0Over2_ThrowsException()
    {
        Fraction fraction = new(0, 2);

        Assert.ThrowsExactly<DivideByZeroException>(() => fraction.Invert());
    }

    [TestMethod]
    public void Pow_2Over3To0_Expect1Over1()
    {
        Fraction real = new(2, 3);
        real = real.Pow(0);

        Fraction expected = new(1, 1);

        Assert.AreEqual(expected, real);
    }

    [TestMethod]
    public void Pow_2Over3To1_Expect2Over3()
    {
        Fraction real = new(2, 3);
        real = real.Pow(1);

        Fraction expected = new(2, 3);

        Assert.AreEqual(expected, real);
    }

    [TestMethod]
    public void Pow_3Over4ToNeg2_Expect16Over9()
    {
        Fraction fraction = new(3, 4);

        fraction = fraction.Pow(-2);

        Fraction real = new(16, 9);

        Assert.AreEqual(real.Numerator, fraction.Numerator);
        Assert.AreEqual(real.Denominator, fraction.Denominator);
    }

    [TestMethod]
    public void Pow_3Over4To3_Expect27Over64()
    {
        Fraction fraction = new(3, 4);

        fraction = fraction.Pow(3);

        Fraction real = new(27, 64);

        Assert.AreEqual(real.Numerator, fraction.Numerator);
        Assert.AreEqual(real.Denominator, fraction.Denominator);
    }

    [TestMethod]
    public void SwapSign_2Over7_ExpectNeg2OverNeg7()
    {
        Fraction fraction = new(2, 7);

        fraction = fraction.SwapSign();

        Fraction expected = new(-2, -7);

        Assert.AreEqual(expected, fraction);
    }

    [TestMethod]
    public void ToSimplest_15Over20_Return3Over4()
    {
        Fraction fraction = new(15, 20);
        Fraction simplest = fraction.ToSimplest();

        Fraction expected = new(3, 4);

        Assert.AreEqual(expected, simplest);
    }

    [TestMethod]
    public void Abs_3Over5_Expect3Over5()
    {
        Fraction fraction = new(3, 5);

        fraction = Fraction.Abs(fraction);

        Fraction real = new(3, 5);

        Assert.AreEqual(real.Numerator, fraction.Numerator);
        Assert.AreEqual(real.Denominator, fraction.Denominator);
    }

    [TestMethod]
    public void Abs_3OverNeg5_ExpectPos3Over5()
    {
        Fraction fraction = new(3, -5);

        fraction = Fraction.Abs(fraction);

        Fraction real = new(3, 5);

        Assert.AreEqual(real.Numerator, fraction.Numerator);
        Assert.AreEqual(real.Denominator, fraction.Denominator);
    }

    [TestMethod]
    public void Abs_Neg3Over5_ExpectPos3Over5()
    {
        Fraction fraction = new(-3, 5);

        fraction = Fraction.Abs(fraction);

        Fraction real = new(3, 5);

        Assert.AreEqual(real.Numerator, fraction.Numerator);
        Assert.AreEqual(real.Denominator, fraction.Denominator);
    }

    [TestMethod]
    public void ContinuedFraction_4_Returns4()
    {
        Fraction frac = new(4);

        List<BigInteger> realContFrac = new() { 4 };

        List<BigInteger> contFrac = Fraction.ContinuedFraction(frac);

        CollectionAssert.AreEqual(contFrac, realContFrac);
    }

    [TestMethod]
    public void ContinuedFraction_61overNeg27_ReturnsCorrect()
    {
        Fraction frac = new(61, -27);

        List<BigInteger> realContFrac = new() { -3, 1, 2, 1, 6 };

        List<BigInteger> contFrac = Fraction.ContinuedFraction(frac);

        CollectionAssert.AreEqual(contFrac, realContFrac);
    }

    [TestMethod]
    public void ContinuedFraction_415over93_ReturnsCorrect()
    {
        Fraction frac = new(415, 93);

        List<BigInteger> realContFrac = new() { 4, 2, 6, 7 };

        List<BigInteger> contFrac = Fraction.ContinuedFraction(frac);

        CollectionAssert.AreEqual(contFrac, realContFrac);
    }

    [TestMethod]
    public void ContinuedFraction_Neg61over27_ReturnsCorrect()
    {
        Fraction frac = new(-61, 27);

        List<BigInteger> realContFrac = new() { -3, 1, 2, 1, 6 };

        List<BigInteger> contFrac = Fraction.ContinuedFraction(frac);

        CollectionAssert.AreEqual(contFrac, realContFrac);
    }

    [TestMethod]
    public void PutOnCommonDenominator_2over3And3Over2_Return4over6And9Over6()
    {
        Fraction frac1 = new(2, 3);
        Fraction frac2 = new(3, 2);

        (frac1, frac2) = Fraction.PutOnCommonDenominator(frac1, frac2);

        Fraction realFrac1 = new(4, 6);
        Fraction realFrac2 = new(9, 6);

        Assert.AreEqual(realFrac1.Numerator, frac1.Numerator);
        Assert.AreEqual(realFrac1.Denominator, frac1.Denominator);

        Assert.AreEqual(realFrac2.Numerator, frac2.Numerator);
        Assert.AreEqual(realFrac2.Denominator, frac2.Denominator);
    }
}

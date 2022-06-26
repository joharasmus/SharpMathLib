namespace SharpFractionsTest;

[TestClass]
public class ComparisonTest
{
    [TestMethod]
    public void Equality_5Over2And4Over3_ReturnFalse()
    {
        Fraction frac1 = new(5, 2);
        Fraction frac2 = new(4, 3);

        bool areEqual = frac1 == frac2;

        Assert.IsFalse(areEqual);
    }

    [TestMethod]
    public void NotEqual_5Over2And4Over3_ReturnTrue()
    {
        Fraction frac1 = new(5, 2);
        Fraction frac2 = new(4, 3);

        bool areNotEqual = frac1 != frac2;

        Assert.IsTrue(areNotEqual);
    }

    [TestMethod]
    public void LessThan_5Over2And4Over2_ReturnFalse()
    {
        Fraction frac1 = new(5, 2);
        Fraction frac2 = new(4, 3);

        bool isLessThan = frac1 < frac2;

        Assert.IsFalse(isLessThan);
    }

    [TestMethod]
    public void GreaterThan_5Over2And3Over3_ReturnTrue()
    {
        Fraction frac1 = new(5, 2);
        Fraction frac2 = new(3, 3);

        bool greaterThan = frac1 > frac2;

        Assert.IsTrue(greaterThan);
    }

    [TestMethod]
    public void LessThanOrEqual_5Over2And5Over2_ReturnTrue()
    {
        Fraction frac1 = new(5, 2);
        Fraction frac2 = new(5, 2);

        bool isLessThanOrEqual = frac1 <= frac2;

        Assert.IsTrue(isLessThanOrEqual);
    }

    [TestMethod]
    public void GreaterThanOrEqual_5Over2And5Over2_ReturnTrue()
    {
        Fraction frac1 = new(5, 2);
        Fraction frac2 = new(5, 2);

        bool greaterOrEqual = frac1 >= frac2;

        Assert.IsTrue(greaterOrEqual);
    }

    [TestMethod]
    public void Equals_String_ReturnFalse()
    {
        Fraction frac = new(1, 2);

        string str = "bobo";

        bool equals = frac.Equals(str);

        Assert.IsFalse(equals);
    }

    [TestMethod]
    public void Compare_7Over11And7Over11_Return0()
    {
        Fraction frac1 = new(7, 11);
        Fraction frac2 = new(7, 11);

        int compared = Fraction.Compare(frac1, frac2);

        Assert.AreEqual(BigInteger.Zero, compared);
    }

    [TestMethod]
    public void Compare_7Over11And11Over11_ReturnNeg1()
    {
        Fraction frac1 = new(7, 11);
        Fraction frac2 = new(11, 11);

        int compared = Fraction.Compare(frac1, frac2);

        Assert.AreEqual(BigInteger.MinusOne, compared);
    }

    [TestMethod]
    public void CompareTo_5Over2And2Over5_Return1()
    {
        Fraction frac1 = new(5, 2);
        Fraction frac2 = new(2, 5);

        int compared = frac1.CompareTo(frac2);

        Assert.AreEqual(compared, 1);
    }

    [TestMethod]
    public void Equals_5Over2And2Over5_ReturnFalse()
    {
        Fraction frac1 = new(5, 2);
        Fraction frac2 = new(2, 5);

        bool areEqual = frac1.Equals(frac2);

        Assert.IsFalse(areEqual);
    }


}

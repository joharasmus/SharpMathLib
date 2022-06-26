namespace SharpFractionsTest;

[TestClass]
public class ComparisonTest
{
    [TestMethod]
    public void Equals_5Over2And2Over5_ReturnFalse()
    {
        Fraction frac1 = new(5, 2);
        Fraction frac2 = new(2, 5);

        bool areEqual = frac1.Equals(frac2);

        Assert.IsFalse(areEqual);
    }

    [TestMethod]
    public void Compare_7Over11And7Over11_Return0()
    {
        Fraction frac1 = new(7, 11);
        Fraction frac2 = new(7, 11);

        int compared = Fraction.Compare(frac1, frac2);

        Assert.AreEqual(BigInteger.Zero, compared);
    }
}

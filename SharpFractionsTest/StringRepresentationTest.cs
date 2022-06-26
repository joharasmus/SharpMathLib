namespace SharpFractionsTest;

[TestClass]
public class StringRepresentationTest
{
    [TestMethod]
    public void ToString_715Over25_ReturnRight()
    {
        Fraction toParse = new(715, 25);

        string real = toParse.ToString();

        string exprected = "715/25";

        Assert.AreEqual(exprected, real);
    }

    [TestMethod]
    public void TryParse_NullString_ThrowException()
    {
        string? toParse = null;

        Assert.ThrowsException<ArgumentNullException>(() => Fraction.TryParse(toParse!, out Fraction frac));
    }

    [TestMethod]
    public void TryParse_InvalidString_ReturnFalse()
    {
        string toParse = "looks/like/a/path";

        bool success = Fraction.TryParse(toParse, out var fraction);

        Fraction expected = Fraction.Zero;

        Assert.IsFalse(success);
        Assert.AreEqual(expected, fraction);
    }

    [TestMethod]
    public void TryParse_InvalidString_ReturnFalse2()
    {
        string toParse = "/unFrac";

        Fraction expected = Fraction.Zero;

        bool success = Fraction.TryParse(toParse, out var fraction);

        Assert.IsFalse(success);
        Assert.AreEqual(expected, fraction);
    }

    [TestMethod]
    public void TryParse_InvalidString_ReturnFalse3()
    {
        string toParse = "notAFrac/731";

        Fraction expected = Fraction.Zero;

        bool success = Fraction.TryParse(toParse, out var fraction);

        Assert.IsFalse(success);
        Assert.AreEqual(expected, fraction);
    }

    [TestMethod]
    public void TryParse_ValidStringStartWith0_CorrectFraction()
    {
        string toParse = "55/0731";

        Fraction expected = new(55, 731);

        bool success = Fraction.TryParse(toParse, out var fraction);

        Assert.IsTrue(success);
        Assert.AreEqual(expected, fraction);
    }

    [TestMethod]
    public void TryParse_ValidString_CorrectFraction()
    {
        string toParse = "55/731";

        Fraction expected = new(55, 731);

        bool success = Fraction.TryParse(toParse, out var fraction);

        Assert.IsTrue(success);
        Assert.AreEqual(expected, fraction);
    }
}

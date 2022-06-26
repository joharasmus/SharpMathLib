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
    public void TryParse_ValidString_CorrectFraction()
    {
        string toParse = "55/731";

        Fraction expected = new(55, 731);

        bool success = Fraction.TryParse(toParse, out var fraction);

        Assert.IsTrue(success);
        Assert.AreEqual(expected, fraction);
    }
}

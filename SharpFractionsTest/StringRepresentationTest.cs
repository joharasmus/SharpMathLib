namespace SharpFractionsTest;

[TestClass]
public class StringRepresentationTest
{
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

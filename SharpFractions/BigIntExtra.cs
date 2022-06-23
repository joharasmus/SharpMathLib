namespace SharpFractions;

public static class BigIntExtra
{
    public static BigInteger LeastCommonMultiple (BigInteger bigInt1, BigInteger bigInt2)
    {
        if (bigInt1 == 0 && bigInt2 == 0) throw new ArgumentException("LCM(a, b) is ony defined where both a and b are not 0");
        if (bigInt1 == 0) return 0;
        if (bigInt2 == 0) return 0;
        return BigInteger.Abs(bigInt1 * bigInt2) / BigInteger.GreatestCommonDivisor(bigInt1, bigInt2);
    }
}

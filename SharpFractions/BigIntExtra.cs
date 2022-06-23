namespace SharpMathLib;

public static class BigIntExtra
{
    public static BigInteger LeastCommonMultiple (BigInteger bigInt1, BigInteger bigInt2)
    {
        return BigInteger.Abs(bigInt1 * bigInt2) / BigInteger.GreatestCommonDivisor(bigInt1, bigInt2);
    }
}

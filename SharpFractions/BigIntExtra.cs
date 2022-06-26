namespace SharpFractions;

public static class BigIntExtra
{
    /// <summary>
    /// Calculates the least common multiple of two BigInteger
    /// </summary>
    /// <param name="bigInt1"></param>
    /// <param name="bigInt2"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static BigInteger LeastCommonMultiple (BigInteger bigInt1, BigInteger bigInt2)
    {
        if (bigInt1 == 0 && bigInt2 == 0) throw new ArgumentException("LCM(a, b) is ony defined when both a and b are not 0");

        if (bigInt1 == 0) return 0;
        if (bigInt2 == 0) return 0;

        return BigInteger.Abs(bigInt1 * bigInt2) / BigInteger.GreatestCommonDivisor(bigInt1, bigInt2);
    }
}

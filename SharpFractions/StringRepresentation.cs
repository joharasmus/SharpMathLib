namespace SharpFractions;

public readonly partial struct Fraction : IComparable<Fraction>, IEquatable<Fraction>
{
    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }

    public static bool TryParse(string toParse, out Fraction frac)
    {
        if (toParse == null) throw new ArgumentNullException(nameof(toParse));

        frac = Zero;

        if (toParse.Count(c => c == '/') != 1) return false;

        string[] numDen = toParse.Split('/');

        string numerator = numDen[0];
        string denominator = numDen[1];

        if (numerator.Length == 0 || denominator.Length == 0) return false;

        bool successNumParse = BigInteger.TryParse(numerator, out BigInteger num);
        bool successDenParse = BigInteger.TryParse(denominator, out BigInteger den);

        if (!(successNumParse && successDenParse)) return false;

        frac = new(num, den);
        return true;
    }
}

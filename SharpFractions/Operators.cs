namespace SharpFractions;

public readonly partial struct Fraction : IComparable<Fraction>, IEquatable<Fraction>
{
    public static Fraction operator +(Fraction frac)
    {
        return new(frac.Numerator, frac.Denominator);
    }

    public static Fraction operator +(Fraction left, Fraction right)
    {
        (left, right) = PutOnCommonDenominator(left, right);

        return new(left.Numerator + right.Numerator, left.Denominator);
    }

    public static Fraction operator -(Fraction frac)
    {
        return new(-frac.Numerator, frac.Denominator);
    }

    public static Fraction operator -(Fraction left, Fraction right)
    {
        (left, right) = PutOnCommonDenominator(left, right);

        return new(left.Numerator - right.Numerator, left.Denominator);
    }

    public static Fraction operator *(Fraction left, Fraction right)
    {
        return new(left.Numerator * right.Numerator, left.Denominator * right.Denominator);
    }

    public static Fraction operator /(Fraction left, Fraction right)
    {
        if (right.Numerator == 0) throw new DivideByZeroException();

        return new(left.Numerator * right.Denominator, left.Denominator * right.Numerator);
    }


    // For interaction with integer types:

    public static implicit operator Fraction(BigInteger bigInteger) => new(bigInteger);
    public static implicit operator Fraction(long longInteger) => new(longInteger);
    public static implicit operator Fraction(int integer) => new(new(integer));
    public static implicit operator Fraction(short shortInteger) => new(new(shortInteger));
}

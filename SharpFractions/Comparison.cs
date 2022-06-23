namespace SharpFractions;

public readonly partial struct Fraction : IComparable<Fraction>, IEquatable<Fraction>
{
    // Comparisons:
    public static bool operator ==(Fraction frac1, Fraction frac2) => Compare(frac1, frac2) == 0;
    public static bool operator !=(Fraction frac1, Fraction frac2) => Compare(frac1, frac2) != 0;
    public static bool operator <(Fraction frac1, Fraction frac2) => Compare(frac1, frac2) == -1;
    public static bool operator >(Fraction frac1, Fraction frac2) => Compare(frac1, frac2) == 1;
    public static bool operator <=(Fraction frac1, Fraction frac2) => Compare(frac1, frac2) != 1;
    public static bool operator >=(Fraction frac1, Fraction frac2) => Compare(frac1, frac2) != -1;

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is null) return false;
        if (obj is not Fraction frac) return false;
        return Compare(this, frac) == 0;
    }

    public static int Compare(Fraction frac1, Fraction frac2)
    {
        (frac1, frac2) = PutOnCommonDenominator(frac1, frac2);

        if (frac1.Numerator > frac2.Numerator) return 1;
        if (frac1.Numerator < frac2.Numerator) return -1;
        return 0;
    }

    public int CompareTo(Fraction other) => Compare(this, other);
    public bool Equals(Fraction other) => Compare(this, other) == 0;
    public override int GetHashCode() => (Numerator, Denominator).GetHashCode();
}

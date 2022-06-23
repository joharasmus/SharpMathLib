using System.Diagnostics.CodeAnalysis;

namespace SharpMathLib;

public readonly struct Fraction : IComparable<Fraction>, IEquatable<Fraction>
{
    public readonly BigInteger Numerator;
    public readonly BigInteger Denominator;

    public Fraction(BigInteger num, BigInteger den)
    {
        if (den == 0) throw new DivideByZeroException();

        Numerator = num;
        Denominator = den;
    }

    public Fraction(BigInteger integer) : this(integer, 1) { }

    public Fraction ExpandBy(BigInteger integer)
    {
        return new(Numerator * integer, Denominator);
    }

    public Fraction Invert() => new(Denominator, Numerator);

    public Fraction Pow(int power)
    {
        if (power < 0) return Invert().Pow(-power);

        return new(
            BigInteger.Pow(Numerator, power), 
            BigInteger.Pow(Denominator, power));
    }

    public Fraction ToSimplest()
    {
        BigInteger gcdOfNumDen = BigInteger.GreatestCommonDivisor(Numerator, Denominator);
        return new(Numerator / gcdOfNumDen, Denominator / gcdOfNumDen);
    }

    public bool IsInt => Numerator % Denominator == 0;
    public bool IsZero => Numerator == 0;
    public bool IsOne => Numerator == Denominator;
    public int Sign => GetSign();

    private int GetSign()
    {
        if (Numerator == 0) return 0;
        return Numerator.Sign == Denominator.Sign ? 1 : -1;
    }

    public static Fraction Abs(Fraction fraction)
    {
        if (fraction.Sign != -1) return fraction;

        //Make sure to remove the minus sign:
        if (fraction.Numerator < 0) return new(fraction.Numerator * -1, fraction.Denominator);

        return new(fraction.Numerator, fraction.Denominator * -1);
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

    // Always puts on a positive denominator
    public static (Fraction, Fraction) PutOnCommonDenominator(Fraction frac1, Fraction frac2)
    {
        if (frac1.Denominator == frac2.Denominator) return (frac1, frac2);

        BigInteger newDenom = BigIntExtra.LeastCommonMultiple(frac1.Denominator, frac2.Denominator);
        BigInteger toExpandFrac1By = newDenom / frac1.Denominator;
        BigInteger toExpandFrac2By = newDenom / frac2.Denominator;

        return (frac1.ExpandBy(toExpandFrac1By), frac2.ExpandBy(toExpandFrac2By));
    }

    public static bool TryParse(string toParse, out Fraction frac)
    {
        if (toParse == null) throw new ArgumentNullException(nameof(toParse));

        frac = new(0);

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


    public static Fraction MinusOne => new(-1);
    public static Fraction One => new(1);
    public static Fraction Zero => new(0);


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

    public override int GetHashCode() => (Numerator, Denominator).GetHashCode();

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }

    // For interaction with other number types:

    public static implicit operator Fraction(BigInteger bigInteger) => new(bigInteger);    
    
}

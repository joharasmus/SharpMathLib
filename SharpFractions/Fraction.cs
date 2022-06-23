namespace SharpFractions;

public readonly partial struct Fraction : IComparable<Fraction>, IEquatable<Fraction>
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


    public bool IsInt   => Numerator % Denominator == 0;
    public bool IsZero  => Numerator == 0;
    public bool IsOne   => Numerator == Denominator;

    public int Sign 
    {
        get 
        {
            if (Numerator == 0) return 0;
            return Numerator.Sign == Denominator.Sign ? 1 : -1;
        }
    }

    public BigInteger Whole => Numerator / Denominator;
    public BigInteger Part  => Numerator % Denominator;
    public (BigInteger, Fraction) Mixed => (Whole, new(Part, Denominator)); 

    public static Fraction MinusOne => new(-1);
    public static Fraction One      => new(1);
    public static Fraction Zero     => new(0);


    public Fraction ExpandBy(BigInteger integer)
    {
        return new(Numerator * integer, Denominator);
    }

    public Fraction Invert()
    {
        if (Numerator.IsZero) throw new DivideByZeroException();
        return new(Denominator, Numerator);
    }

    public Fraction Pow(int power)
    {
        if (power == 0) return One;
        if (power == 1) return this;

        if (power < 0) return Invert().Pow(-power);

        return new(
            BigInteger.Pow(Numerator, power),
            BigInteger.Pow(Denominator, power));
    }

    public Fraction SwapSign() => new(-Numerator, -Denominator);

    public Fraction ToSimplest()
    {
        BigInteger gcdOfNumDen = BigInteger.GreatestCommonDivisor(Numerator, Denominator);
        return new(Numerator / gcdOfNumDen, Denominator / gcdOfNumDen);
    }



    public static Fraction Abs(Fraction fraction)
    {
        if (fraction.Sign != -1) return fraction;

        //Make sure to remove the minus sign:
        if (fraction.Numerator < 0) return new(fraction.Numerator * -1, fraction.Denominator);

        return new(fraction.Numerator, fraction.Denominator * -1);
    }

    public static List<BigInteger> ContinuedFraction(Fraction frac)
    {
        if (frac.IsInt) return new() { frac.Whole };    // Also trivial

        //Ensure positive denom:

        if (frac.Denominator < 0) frac = new(-frac.Numerator, -frac.Denominator);

        //For the first term we'll have to deal with the possibility of frac being negative:

        BigInteger first;

        if (frac.Numerator < 0)
        {
            first = frac.Whole - 1;
        }
        else
        {
            first = frac.Whole;
        }

        List<BigInteger> coeffiecients = new() { first };

        frac = (frac - first).Invert();

        // Now, redo until completion:

        while (true)
        {
            coeffiecients.Add(frac.Whole);

            frac = new(frac.Part, frac.Denominator);

            if (frac.IsZero) break;

            frac = frac.Invert();
        }

        return coeffiecients;
    }

    // Always puts on a positive denominator
    public static (Fraction, Fraction) PutOnCommonDenominator(Fraction frac1, Fraction frac2)
    {
        if (frac1.Denominator == frac2.Denominator) return (frac1, frac2);

        BigInteger newDenom = BigIntExtra.LeastCommonMultiple(frac1.Denominator, frac2.Denominator);
        BigInteger toExpandFrac1By = newDenom / frac1.Denominator;
        BigInteger toExpandFrac2By = newDenom / frac2.Denominator;

        return (frac1.ExpandBy(toExpandFrac1By), frac2.ExpandBy(toExpandFrac2By));
    }
}

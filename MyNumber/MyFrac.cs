using System;
using System.Numerics;

namespace lab5.MyNumber;

class MyFrac : IMyNumber<MyFrac>
{
    private BigInteger nom, denom;

    public BigInteger Nom { get => nom; set => nom = value; }
    public BigInteger Denom
    {
        get => denom;
        set => denom = value != 0
            ? value
            : throw new DivideByZeroException("Division by a zero divisor.");
    }

    public MyFrac(BigInteger nom, BigInteger denom)
    {
        if (denom == 0)
            throw new DivideByZeroException("The denominator of a fraction cannot be equal to 0.");

        if (denom < 0)
        {
            nom = -nom;
            denom = -denom;
        }

        BigInteger gcd = BigInteger.GreatestCommonDivisor(nom, denom);

        this.nom = nom / gcd;
        this.denom = denom / gcd;
    }

    public MyFrac(BigInteger nom) : this(nom, 1) { }

    public MyFrac(int nom, int denom) : this((BigInteger)nom, (BigInteger)denom) { }

    public MyFrac(string str)
    {
        var parts = str.Split('/');
        if (parts.Length != 2)
            throw new ArgumentException("Invalid fraction format. Expecting ‘numerator/denominator’.");

        try
        {
            BigInteger n = BigInteger.Parse(parts[0].Trim());
            BigInteger d = BigInteger.Parse(parts[1].Trim());

            if (d == 0) throw new DivideByZeroException();

            if (d < 0) { n = -n; d = -d; }

            BigInteger gcd = BigInteger.GreatestCommonDivisor(n, d);

            Nom = n / gcd;
            Denom = d / gcd;
        }
        catch (FormatException)
        {
            throw new ArgumentException("The string contains non-numeric characters.");
        }
        catch (DivideByZeroException)
        {
            throw new DivideByZeroException("The denominator in the row cannot be zero.");
        }
    }

    public override string ToString()
    {
        return $"{Nom}/{Denom}";
    }

    public MyFrac Add(MyFrac that)
    {
        return new MyFrac(
            this.Nom * that.Denom + this.Denom * that.Nom, // ad + bc
            this.Denom * that.Denom                        // bd
        );
    }

    public MyFrac Subtract(MyFrac that)
    {
        return new MyFrac(
            this.Nom * that.Denom - this.Denom * that.Nom, // ad - bc
            this.Denom * that.Denom                        // bd
        );
    }

    public MyFrac Multiply(MyFrac that)
    {
        return new MyFrac(
            this.Nom * that.Nom,     // ac
            this.Denom * that.Denom  // bd
        );
    }

    public MyFrac Divide(MyFrac that)
    {
        if (that.Nom == 0)
            throw new DivideByZeroException("Division by a zero divisor.");

        return new MyFrac(
            this.Nom * that.Denom,
            this.Denom * that.Nom
        );
    }

    public static MyFrac operator +(MyFrac a, MyFrac b) => a.Add(b);
    public static MyFrac operator -(MyFrac a, MyFrac b) => a.Subtract(b);
    public static MyFrac operator *(MyFrac a, MyFrac b) => a.Multiply(b);
    public static MyFrac operator /(MyFrac a, MyFrac b) => a.Divide(b);
}
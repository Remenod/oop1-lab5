using System;

namespace lab5.MyNumber;

class MyComplex : IMyNumber<MyComplex>
{
    double real, imag;

    public double Real { get => real; set => real = value; }
    public double Imag { get => imag; set => imag = value; }

    public MyComplex(double real, double imag)
    {
        Real = real;
        Imag = imag;
    }

    public MyComplex(double real) : this(real, 0) { }

    public MyComplex(string str)
    {
        str = str.Trim();
        if (str.EndsWith("i"))
        {
            str = str.Substring(0, str.Length - 1).Trim();
        }
        else
        {
            throw new ArgumentException("The string must end with ‘i’ for a complex number (ToString format).");
        }

        int splitIndex = str.LastIndexOfAny(new char[] { '+', '-' });

        if (splitIndex <= 0)
        {
            throw new ArgumentException("Invalid format. ‘Re + Imi’ or ‘Re - Imi’ is expected.");
        }

        string realPartStr = str.Substring(0, splitIndex).Trim();
        string imagPartStr = str.Substring(splitIndex).Replace(" ", "").Trim();

        try
        {
            Real = double.Parse(realPartStr);
            Imag = double.Parse(imagPartStr);
        }
        catch
        {
            throw new ArgumentException("Error parsing numbers.");
        }
    }

    public override string ToString()
    {
        if (Imag >= 0)
            return $"{Real} + {Imag}i";
        else
            return $"{Real} - {Math.Abs(Imag)}i";
    }

    public MyComplex Add(MyComplex that)
    {
        return new MyComplex(this.Real + that.Real, this.Imag + that.Imag);
    }

    public MyComplex Subtract(MyComplex that)
    {
        return new MyComplex(this.Real - that.Real, this.Imag - that.Imag);
    }

    public MyComplex Multiply(MyComplex that)
    {
        return new MyComplex(
            this.Real * that.Real - this.Imag * that.Imag, // (ac - bd)
            this.Real * that.Imag + this.Imag * that.Real  // (ad + bc)
        );
    }

    public MyComplex Divide(MyComplex that)
    {
        double denominator = that.Real * that.Real + that.Imag * that.Imag; // c^2 + d^2
        if (Math.Abs(denominator) < 1e-9)
            throw new DivideByZeroException("Division by a complex zero.");

        return new MyComplex(
            (this.Real * that.Real + this.Imag * that.Imag) / denominator, // (ac + bd) / ...
            (this.Imag * that.Real - this.Real * that.Imag) / denominator  // (bc - ad) / ...
        );
    }

    public static MyComplex operator +(MyComplex a, MyComplex b) => a.Add(b);
    public static MyComplex operator -(MyComplex a, MyComplex b) => a.Subtract(b);
    public static MyComplex operator *(MyComplex a, MyComplex b) => a.Multiply(b);
    public static MyComplex operator /(MyComplex a, MyComplex b) => a.Divide(b);
}
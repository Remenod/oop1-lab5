using System;

namespace lab5.MyNumber;

class MyComplex(double real, double imag) : IMyNumber<MyComplex>
{
    public double Real { get => real; set => real = value; } // implement later
    public double Imag { get => imag; set => imag = value; } // implement later

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
using System;

namespace lab5.MyNumber;

class MyComplex(double real, double imagine) : IMyNumber<MyComplex>
{
    public double Real { get => real; set => real = value; } // implement later
    public double Imagine { get => imagine; set => imagine = value; } // implement later

    public MyComplex Add(MyComplex b)
    {
        throw new NotImplementedException();
    }
    public MyComplex Subtract(MyComplex b)
    {
        throw new NotImplementedException();
    }
    public MyComplex Multiply(MyComplex b)
    {
        throw new NotImplementedException();
    }
    public MyComplex Divide(MyComplex b)
    {
        throw new NotImplementedException();
    }

    public static MyComplex operator +(MyComplex a, MyComplex b) => a.Add(b);
    public static MyComplex operator -(MyComplex a, MyComplex b) => a.Subtract(b);
    public static MyComplex operator *(MyComplex a, MyComplex b) => a.Multiply(b);
    public static MyComplex operator /(MyComplex a, MyComplex b) => a.Divide(b);

}
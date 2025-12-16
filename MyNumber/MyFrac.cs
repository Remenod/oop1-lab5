using System;
using System.Numerics;

namespace lab5.MyNumber;

class MyFrac(BigInteger nom, BigInteger denom) : IMyNumber<MyFrac>
{
    public BigInteger Nom { get => nom; set => nom = value; } // implement later
    public BigInteger Denom { get => denom; set => denom = value; } // implement later

    public MyFrac Add(MyFrac b)
    {
        throw new NotImplementedException();
    }
    public MyFrac Subtract(MyFrac b)
    {
        throw new NotImplementedException();
    }
    public MyFrac Multiply(MyFrac b)
    {
        throw new NotImplementedException();
    }
    public MyFrac Divide(MyFrac b)
    {
        throw new NotImplementedException();
    }

    public static MyFrac operator +(MyFrac a, MyFrac b) => a.Add(b);
    public static MyFrac operator -(MyFrac a, MyFrac b) => a.Subtract(b);
    public static MyFrac operator *(MyFrac a, MyFrac b) => a.Multiply(b);
    public static MyFrac operator /(MyFrac a, MyFrac b) => a.Divide(b);


}
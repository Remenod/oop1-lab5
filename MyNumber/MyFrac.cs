using System;
using System.Numerics;

namespace lab5.MyNumber;

class MyFrac(BigInteger nom, BigInteger denom) : IMyNumber<MyFrac>
{
    public BigInteger Nom { get => nom; set => nom = value; } // implement later
    public BigInteger Denom { get => denom; set => denom = value; } // implement later

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
        return new MyFrac(
            this.Nom * that.Denom,   // ad
            this.Denom * that.Nom    // bc
        );
    }

    public static MyFrac operator +(MyFrac a, MyFrac b) => a.Add(b);
    public static MyFrac operator -(MyFrac a, MyFrac b) => a.Subtract(b);
    public static MyFrac operator *(MyFrac a, MyFrac b) => a.Multiply(b);
    public static MyFrac operator /(MyFrac a, MyFrac b) => a.Divide(b);


}
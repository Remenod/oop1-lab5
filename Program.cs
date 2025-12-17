using System;
using lab5.MyNumber;

namespace lab5;

internal class Program
{
    static void TestAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine("\n=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        T aPlusB = a.Add(b);
        Console.WriteLine("(a + b) = " + aPlusB);
        Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
        Console.WriteLine(" = = = ");
        T curr = a.Multiply(a);
        T wholeRightPart = curr;
        curr = a.Multiply(b);
        curr = curr.Add(curr);
        wholeRightPart = wholeRightPart.Add(curr);
        curr = b.Multiply(b);
        wholeRightPart = wholeRightPart.Add(curr);
        Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
        Console.WriteLine("=== Finishing testing ===");
    }

    static void TestSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine("\n=== Starting testing (a^2-b^2)/(a+b) = a-b with a = " + a + ", b = " + b + " ===");

        try
        {
            T aMinusB = a.Subtract(b);
            Console.WriteLine("(a - b) = " + aMinusB);

            T aSq = a.Multiply(a);       // a^2
            T bSq = b.Multiply(b);       // b^2
            T diffSq = aSq.Subtract(bSq); // a^2 - b^2
            Console.WriteLine("(a^2 - b^2) = " + diffSq);

            T sum = a.Add(b);            // a + b
            Console.WriteLine("(a + b) = " + sum);

            T result = diffSq.Divide(sum);
            Console.WriteLine("(a^2 - b^2) / (a + b) = " + result);

            Console.WriteLine("Result match: " + result.ToString().Equals(aMinusB.ToString()));
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("CAUGHT EXCEPTION: Division by zero occurred (expected behavior if a = -b).");
        }

        Console.WriteLine("=== Finishing testing ===");
    }

    static void Main(string[] args)
    {
        MyFrac f1 = new MyFrac(1, 3);
        MyFrac f2 = new MyFrac(1, 6);

        TestAPlusBSquare(f1, f2);
        TestSquaresDifference(f1, f2);

        MyComplex c1 = new MyComplex(1, 3);
        MyComplex c2 = new MyComplex(1, 6);

        TestAPlusBSquare(c1, c2);
        TestSquaresDifference(c1, c2);

        Console.WriteLine("\n--- Testing Division by Zero Exception ---");
        TestSquaresDifference(new MyFrac(1, 2), new MyFrac(-1, 2));

        Console.WriteLine("\n=== Testing Sorting MyFrac array ===");
        MyFrac[] fractions = new MyFrac[]
        {
            new MyFrac(1, 2),
            new MyFrac(10, 1),
            new MyFrac(1, 3),
            new MyFrac(-5, 2),
            new MyFrac(3, 4)
        };

        Console.WriteLine("Before sorting:");
        Console.WriteLine(string.Join(", ", (object[])fractions));

        Array.Sort(fractions);

        Console.WriteLine("After sorting:");
        Console.WriteLine(string.Join(", ", (object[])fractions));

        Console.ReadKey();
    }
}
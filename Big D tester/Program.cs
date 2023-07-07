using Big_D_V2;
using System.Diagnostics;
using System.Net.Http.Headers;

public class Program
{
    public static void Main(string[] args)
    {
        Big_D a = new Big_D(1, 2);
        Big_D b = new Big_D(2, 1);
        Big_D c = new Big_D();
        Big_D d = new Big_D(1, 3 * Math.Pow(10, 242));
        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(c * a);
        Console.WriteLine(a + b);
        Console.WriteLine(b + a);
        Console.WriteLine(a - b);
        Console.WriteLine(a * b);
        Console.WriteLine(d);
        Console.WriteLine((Big_D.Pow(Big_D.Pow(new Big_D(2, 5), -1), -1) == new Big_D(2, 5)) + $", {Big_D.Pow(Big_D.Pow(new Big_D(2, 5), -1), -1)}:{new Big_D(2, 5)}");
        Console.WriteLine(new Big_D(5, 0) / 10 + "\n\n");

        Big_D i = new Big_D(1.5, 2);
        Big_D j = new Big_D(1, 4);
        Big_D m = new Big_D();
        int integer = 5;
        Big_D asd = new Big_D(integer);
        Console.WriteLine(asd.ToString());
        Console.WriteLine(i);
        // Console.WriteLine(Big_D.LogB(j, 10));
        Console.WriteLine(i + j);
        Console.WriteLine(i * j);
        Console.WriteLine(i * 1);
        Console.WriteLine(m + 1);
        Console.WriteLine(Big_D.Pow(i, 5));

        Big_D x = new Big_D(1, 2);
        Big_D y = new Big_D(1, 1);
        Big_D z = new Big_D(1, 3);
        Big_D zz = new Big_D(1, 4);
        Console.WriteLine("\n" + y);
        Console.WriteLine(x);
        Console.WriteLine(z);
        Console.WriteLine(zz);
        Console.WriteLine(new Big_D(1, 64) + new Big_D(1, 16));
        Console.WriteLine(new Big_D(1, Math.Pow(10, 100)));
    }
}
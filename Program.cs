class Fraction
{
    private int numerator;
    private int denominator;

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Знаменатель не может быть равен нулю");
        }

        this.numerator = numerator;
        this.denominator = denominator;
    }

    public void Simplify()
    {
        int gcd = GCD(this.numerator, this.denominator);
        this.numerator /= gcd;
        this.denominator /= gcd;
    }

    public Fraction Add(Fraction other_fraction)
    {
        int new_numerator = this.numerator * other_fraction.denominator + other_fraction.numerator * this.denominator;
        int new_denominator = this.denominator * other_fraction.denominator;
        Fraction result = new Fraction(new_numerator, new_denominator);
        result.Simplify();
        return result;
    }

    public int GetWholePart()
    {
        return this.numerator / this.denominator;
    }

    public override string ToString()
    {
        string msg = this.numerator.ToString() + '/' + this.denominator.ToString();
        return msg;
    }

    private static int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction(2, 4);
        Console.WriteLine($"f1: {f1}"); // output: f1: 2/4
        f1.Simplify();
        Console.WriteLine($"f1 (simplified): {f1}"); // output: f1 (simplified): 1/2

        Fraction f2 = new Fraction(3, 5);
        Console.WriteLine($"f2: {f2}"); // output: f2: 3/5
        f2.Simplify();
        Console.WriteLine($"f2 (simplified): {f2}"); // output: f2 (simplified): 3/5

        Fraction f3 = f1.Add(f2);
        Console.WriteLine($"f1 + f2 = {f3}"); // output: f1 + f2 = 11/10

        Fraction f4 = new Fraction(7, 4);
        Console.WriteLine($"f4: {f4}"); // output: f4: 7/4
        int whole_part = f4.GetWholePart();
        Console.WriteLine($"Whole part of f4: {whole_part}"); // output: Whole part of f4: 1

       // Fraction f5 = new Fraction(1, 0);
        // The following line throws an ArgumentException, because the denominator cannot be zero
        // Console.WriteLine($"f5: {f5}");
    }
}

namespace FirstPracticeAfterCource;
using System.Numerics;

public delegate T Operation<T>(T a, T b) where T : INumber<T>;

public class Calculator
{
    public static T Calculate<T>(T a, T b, Operation<T> operation) where T : INumber<T>
    {
        return operation(a, b);
    }

    public static T Add<T>(T a, T b) where T : INumber<T>
    {
        return a + b;
    }
    
    public static T Subtract<T>(T a, T b) where T : INumber<T>
    {
        return a - b;
    }
    
    public static T Multiply<T>(T a, T b) where T : INumber<T>
    {
        return a * b;
    }
    
    public static T Divide<T>(T a, T b) where T : INumber<T>
    {
        if (b == T.Zero)
        {
            throw new DivideByZeroException("Divide by zero is not available!");
        }

        return a / b;
    }

    public static double Pow(double a, double b)
    {
        return Math.Pow(a, b);
    }

}
namespace Calculator;

public class ModernCalculator
{
    public static int Total = 0;
    
    public  static int Operation(int a, int b, string op)
    {
        switch (op)
        {
            case "+":
                return a + b;
            case "-":
                 return a - b;
            case "*":
                return a * b;
            case "/":
                return a / b;
            default:
                return 0;
        }
      
    }
    
}
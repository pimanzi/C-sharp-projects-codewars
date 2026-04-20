namespace codewars;

public class MultiplesOf3Or5
{
    public static int Solution(int value)
    {
        int sum = 0;
        if (value < 0)
        {
            return 0;
        }

        for (int i = 1; i < value; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
            {
                sum += i;
            }
        }

        return sum;
    }
}
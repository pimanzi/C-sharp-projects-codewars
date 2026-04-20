namespace codewars;

public class CreatePhoneNumber
{
    public static string Soluton (int[] numbers)
    {
        var dynamicNumbers = numbers.Select(i => i.ToString()).ToList();
        dynamicNumbers.Insert(0, "(");
        dynamicNumbers.Insert(4, ") ");
        dynamicNumbers.Insert(8,"-");
        return string.Concat(dynamicNumbers);

    }
}
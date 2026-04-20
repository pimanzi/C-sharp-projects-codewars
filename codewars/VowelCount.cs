namespace codewars;

public class VowelCount
{
    public static int GetVowelCount(string str)
    {
        int vowelCount = 0;

        vowelCount = str.Count(c => c == 'a' || c == 'i' || c == 'o' || c == 'e' || c == 'u');

        return vowelCount;
    }
}
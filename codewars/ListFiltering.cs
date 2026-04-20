namespace codewars;

public class ListFiltering
{
    public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
    {
        return listOfItems.Where(x => x.GetType() == typeof(int)).Select(x => (int)x);
    }
    // return listOfItems.OfType<int>();
}

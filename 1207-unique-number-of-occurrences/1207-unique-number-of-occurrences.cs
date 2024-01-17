using System.Collections.Generic;

public class Solution
{
    public bool UniqueOccurrences(int[] arr)
    {
        Dictionary<int, int> frequency = new Dictionary<int, int>();

        foreach (var num in arr)
        {
            if (frequency.ContainsKey(num))
                frequency[num]++;
            else
                frequency[num] = 1;
        }

        HashSet<int> uniqueOccurrences = new HashSet<int>(frequency.Values);

        return uniqueOccurrences.Count == frequency.Count;
    }
}
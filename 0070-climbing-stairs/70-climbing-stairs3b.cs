using System.Collections.Generic;

public class Solution
{
    public static List<int> results = new List<int> { 0, 1, 2 };

    public int ClimbStairs(int n)
    {
        for (int i = results.Count; i <= n; i++)
        {
            results.Add(results[i - 1] + results[i - 2]);
        }
        return results[n];
    }
}
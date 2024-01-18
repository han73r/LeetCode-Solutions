using System.Collections.Generic;

public class Solution
{
    public static List<int> results = new List<int> { 0, 1, 2 };
    public static int resultsNumber = 2;

    public int ClimbStairs(int n)
    {
        if (resultsNumber >= n)
            return results[n];

        for (int i = resultsNumber + 1; i <= n; i++)
        {
            results.Add(results[i - 1] + results[i - 2]);
            resultsNumber++;
        }
        return results[n];
    }
}
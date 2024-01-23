using System.Collections.Generic;
using System.Linq;
using System;

public class Solution
{
    public int MaxLength(IList<string> arr, int i = 0, string s = "")
    {
        if (s.Distinct().Count() < s.Length) return 0;

        if (arr.Count == i) return s.Length;

        return Math.Max(
            MaxLength(arr, i + 1, s),
            MaxLength(arr, i + 1, s + arr[i])
        );
    }
}
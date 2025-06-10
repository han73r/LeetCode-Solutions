using System;

public class Solution {
    public int MaxDifference(string s) {
        int[] arr = new int[26];
        foreach (var item in s)
            arr[item - 'a']++;
        int a = 0;
        int b = int.MaxValue;
        foreach (int item in arr) {
            if (item % 2 == 1)
                a = Math.Max(a, item);
            else if (item > 0)
                b = Math.Min(b, item);
        }
        return a - b;
    }
}
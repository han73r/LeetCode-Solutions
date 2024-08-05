using System.Collections.Generic;

public class Solution {
    public string KthDistinct(string[] arr, int k) {
        var dict = CountDistinctStrings(arr);
        int distinctCount = 0;
        foreach (var kvp in dict) {
            if (kvp.Value == 1) {
                distinctCount++;
                if (distinctCount == k) {
                    return kvp.Key;
                }
            }
        }
        return "";
    }
    private Dictionary<string, int> CountDistinctStrings(string[] arr) {
        Dictionary<string, int> counter = new();
        foreach (string str in arr) {
            if (counter.ContainsKey(str)) {
                counter[str]++;
            } else {
                counter.Add(str, 1);
            }
        }
        return counter;
    }
}
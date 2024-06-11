using System.Collections.Generic;

public class Solution {
    public int[] RelativeSortArray(int[] arr1, int[] arr2) {
        Dictionary<int, int> dict1 = new();  // number + count
        List<int> result = new();
        List<int> remaining = new();
        foreach (int i in arr1) {
            if (dict1.ContainsKey(i)) {
                dict1[i]++;
            } else {
                dict1.Add(i, 1);
            }
        }
        foreach (int num in arr2) {
            if (dict1.ContainsKey(num)) {
                while (dict1[num] > 0) {
                    result.Add(num);
                    dict1[num]--;
                }
                dict1.Remove(num);
            }
        }
        foreach (var kvp in dict1) {
            for (int i = 0; i < kvp.Value; i++) {
                remaining.Add(kvp.Key);
            }
        }
        remaining.Sort();
        result.AddRange(remaining);
        return result.ToArray();
    }
}
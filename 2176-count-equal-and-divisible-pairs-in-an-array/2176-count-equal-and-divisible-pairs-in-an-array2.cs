using System.Collections.Generic;

public class Solution {
    public int CountPairs(int[] nums, int k) {
        var dict = new Dictionary<int, List<int>>();
        int n = nums.Length;
        int result = 0;
        for (int i = 0; i < n; i++) {
            if (!dict.ContainsKey(nums[i]))
                dict[nums[i]] = new List<int>();
            dict[nums[i]].Add(i);
        }
        foreach (var entry in dict) {
            var indices = entry.Value;
            int count = indices.Count;
            if (indices.Count < 2) continue;
            for (int i = 0; i < count; i++) {
                for (int j = i + 1; j < count; j++) {
                    if ((indices[i] * indices[j]) % k == 0)
                        result++;
                }
            }
        }
        return result;
    }
}
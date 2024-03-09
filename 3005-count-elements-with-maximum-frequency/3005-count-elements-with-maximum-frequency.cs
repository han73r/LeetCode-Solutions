using System.Collections.Generic;

public class Solution {
    public int MaxFrequencyElements(int[] nums) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        foreach (int val in nums) {
            if (!map.ContainsKey(val))
                map[val] = 0;
            map[val]++;
        }
        int count = 0;
        int max = -1;
        foreach (var pair in map) {
            max = System.Math.Max(max, pair.Value);
        }
        foreach (var pair in map) {
            if (pair.Value == max) {
                count += max;
            }
        }
        return count;
    }
}
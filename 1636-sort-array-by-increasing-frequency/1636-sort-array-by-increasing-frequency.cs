using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] FrequencySort(int[] nums) {
        if (nums.Length == 1) return nums;
        Dictionary<int, int> frequency = new Dictionary<int, int>();
        foreach (var num in nums) {
            if (frequency.ContainsKey(num)) {
                frequency[num]++;
            } else {
                frequency[num] = 1;
            }
        }
        var sorted = nums.OrderBy(num => frequency[num])
                         .ThenByDescending(num => num)
                         .ToArray();
        return sorted;
    }
}
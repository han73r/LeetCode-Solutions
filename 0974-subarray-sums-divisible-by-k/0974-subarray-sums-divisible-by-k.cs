using System.Collections.Generic;

public class Solution {
    public int SubarraysDivByK(int[] nums, int k) {
        Dictionary<int, int> prefixSumCount = new();
        int sum = 0, count = 0;
        prefixSumCount[0] = 1;
        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];
            int remainder = (sum % k + k) % k;
            if (prefixSumCount.ContainsKey(remainder)) {
                count += prefixSumCount[remainder];
            }
            prefixSumCount[remainder] = prefixSumCount.GetValueOrDefault(remainder, 0) + 1;
        }
        return count;
    }
}
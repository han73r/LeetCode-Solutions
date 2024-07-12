using System.Collections.Generic;

public class Solution {
    public int NumSubarraysWithSum(int[] nums, int goal) {
        Dictionary<int, int> prefixSumCount = new Dictionary<int, int>();
        int currentSum = 0;
        int count = 0;
        prefixSumCount[0] = 1;

        foreach (var num in nums) {
            currentSum += num;
            if (prefixSumCount.ContainsKey(currentSum - goal)) {
                count += prefixSumCount[currentSum - goal];
            }
            if (!prefixSumCount.ContainsKey(currentSum)) {
                prefixSumCount[currentSum] = 0;
            }
            prefixSumCount[currentSum]++;
        }
        return count;
    }
}
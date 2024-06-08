using System.Collections.Generic;

public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        Dictionary<int, int> remainderIndexMap = new();
        remainderIndexMap[0] = -1;
        int currentSum = 0;
        for (int i = 0; i < nums.Length; i++) {
            currentSum += nums[i];
            int remainder = currentSum % k;
            if (remainder < 0) {
                remainder += k;
            }
            if (remainderIndexMap.ContainsKey(remainder)) {
                if (i - remainderIndexMap[remainder] > 1) {
                    return true;
                }
            } else {
                remainderIndexMap[remainder] = i;
            }
        }
        return false;
    }
}
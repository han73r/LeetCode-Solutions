using System.Collections.Generic;

public class Solution {
    public bool CanArrange(int[] arr, int k) {
        var remainderCount = new Dictionary<int, int>();
        foreach (var num in arr) {
            int remainder = ((num % k) + k) % k;
            if (!remainderCount.ContainsKey(remainder)) {
                remainderCount[remainder] = 0;
            }
            remainderCount[remainder]++;
        }
        foreach (var num in arr) {
            int remainder = ((num % k) + k) % k;
            if (remainder == 0) {
                if (remainderCount[remainder] % 2 != 0) {
                    return false;
                }
            } else {
                int complement = k - remainder;
                if (!remainderCount.ContainsKey(complement) || remainderCount[complement] != remainderCount[remainder]) {
                    return false;
                }
            }
        }
        return true;
    }
}
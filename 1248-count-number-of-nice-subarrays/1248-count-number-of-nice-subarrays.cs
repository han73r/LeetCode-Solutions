using System.Collections.Generic;

public class Solution {
    public int NumberOfSubarrays(int[] nums, int k) {
        int count = 0;
        int countOdd = 0;
        var oddCountMap = new Dictionary<int, int>();
        oddCountMap[0] = 1;
        foreach (var num in nums) {
            if (num % 2 != 0) {
                countOdd++;
            }
            if (oddCountMap.ContainsKey(countOdd - k)) {
                count += oddCountMap[countOdd - k];
            }
            if (oddCountMap.ContainsKey(countOdd)) {
                oddCountMap[countOdd]++;
            } else {
                oddCountMap[countOdd] = 1;
            }
        }
        return count;
    }
}
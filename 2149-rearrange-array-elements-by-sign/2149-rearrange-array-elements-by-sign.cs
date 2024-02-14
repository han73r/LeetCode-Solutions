using System.Collections.Generic;

public class Solution {
    public int[] RearrangeArray(int[] nums) {
        int[] result = new int[nums.Length];
        List<int> positiveNums = new();
        List<int> negativeNums = new();
        foreach (var num in nums) {
            if (num >= 0) {
                positiveNums.Add(num);
            } else {
                negativeNums.Add(num);
            }
        }
        for (int i = 0; i < result.Length; i++) {
            if (i % 2 == 0) {
                result[i] = positiveNums[0];
                positiveNums.RemoveAt(0);
            } else {
                result[i] = negativeNums[0];
                negativeNums.RemoveAt(0);
            }

        }
        return result;
    }
}
using System.Collections.Generic;
using System;

public class Solution {
    public int MaximumSum(int[] nums) {
        List<(int digitSum, int num)> numPairs = new List<(int, int)>();
        foreach (int num in nums)
            numPairs.Add((GetDigitSum(num), num));
        numPairs.Sort((a, b) =>
            a.digitSum != b.digitSum ? a.digitSum.CompareTo(b.digitSum) : b.num.CompareTo(a.num)
        );
        int maxSum = -1;
        for (int i = 1; i < numPairs.Count; i++)
            if (numPairs[i].digitSum == numPairs[i - 1].digitSum)
                maxSum = Math.Max(maxSum, numPairs[i].num + numPairs[i - 1].num);
        return maxSum;
    }
    private int GetDigitSum(int num) {
        int sum = 0;
        while (num > 0) {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }
}
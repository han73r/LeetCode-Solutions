using System.Collections.Generic;
using System;

public class Solution {
    public int RangeSum(int[] nums, int n, int left, int right) {
        int[] subarraySums = ComputeSumFromArray(nums, n);
        Array.Sort(subarraySums);
        return CountSumFromArray(subarraySums, left - 1, right - 1);
    }
    private int[] ComputeSumFromArray(int[] array, int n) {
        List<int> resultList = new List<int>();
        for (int i = 0; i < n; i++) {
            int sum = 0;
            for (int j = i; j < n; j++) {
                sum += array[j];
                resultList.Add(sum);
            }
        }
        return resultList.ToArray();
    }
    private int CountSumFromArray(int[] array, int left, int right) {
        int MOD = 1_000_000_007;
        long result = 0;
        for (int i = left; i <= right; i++) {
            result = (result + array[i]) % MOD;
        }
        return (int)result;
    }
}
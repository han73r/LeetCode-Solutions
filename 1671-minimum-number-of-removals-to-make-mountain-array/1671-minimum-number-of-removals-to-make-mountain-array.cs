using System.Collections.Generic;
using System;

public class Solution {
    private List<int> LisLength(int[] v) {
        List<int> lis = new List<int> { v[0] };
        List<int> lisLen = new List<int>(new int[v.Length]);
        int l = v.Length;
        for (int i = 0; i < l; i++) {
            lisLen[i] = 1;
        }
        for (int i = 1; i < l; i++) {
            if (v[i] > lis[lis.Count - 1]) {
                lis.Add(v[i]);
            } else {
                int index = lis.BinarySearch(v[i]);
                if (index < 0) {
                    index = ~index;
                }
                lis[index] = v[i];
            }
            lisLen[i] = lis.Count;
        }
        return lisLen;
    }
    public int MinimumMountainRemovals(int[] nums) {
        int n = nums.Length;
        List<int> lis = LisLength(nums);
        Array.Reverse(nums);
        List<int> lds = LisLength(nums);
        lds.Reverse();
        Array.Reverse(nums);
        int removals = int.MaxValue;
        for (int i = 0; i < n; i++) {
            if (lis[i] > 1 && lds[i] > 1) {
                removals = Math.Min(removals, n + 1 - lis[i] - lds[i]);
            }
        }
        return removals;
    }
}
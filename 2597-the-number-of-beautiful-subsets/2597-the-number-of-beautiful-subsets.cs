using System.Collections.Generic;
using System;

public class Solution {
    private int count = 0;
    public int BeautifulSubsets(int[] nums, int k) {
        count = 0;
        Backtrack(nums, 0, new List<int>(), k);
        return count;
    }
    private void Backtrack(int[] nums, int index, List<int> currentSubset, int k) {
        if (currentSubset.Count > 0 && IsBeautiful(currentSubset, k)) {
            count++;
        }
        for (int i = index; i < nums.Length; i++) {
            currentSubset.Add(nums[i]);
            Backtrack(nums, i + 1, currentSubset, k);
            currentSubset.RemoveAt(currentSubset.Count - 1);
        }
    }
    private bool IsBeautiful(List<int> subset, int k) {
        for (int i = 0; i < subset.Count; i++) {
            for (int j = i + 1; j < subset.Count; j++) {
                if (Math.Abs(subset[i] - subset[j]) == k) {
                    return false;
                }
            }
        }
        return true;
    }
}
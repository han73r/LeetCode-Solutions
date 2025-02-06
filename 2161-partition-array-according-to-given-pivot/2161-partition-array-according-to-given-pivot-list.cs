using System.Collections.Generic;

public class Solution {
    public int[] PivotArray(int[] nums, int pivot) {
        List<int> less = new List<int>();
        List<int> equal = new List<int>();
        List<int> greater = new List<int>();
        foreach (int num in nums) {
            if (num < pivot) less.Add(num);
            else if (num == pivot) equal.Add(num);
            else greater.Add(num);
        }
        int index = 0;
        foreach (int num in less) nums[index++] = num;
        foreach (int num in equal) nums[index++] = num;
        foreach (int num in greater) nums[index++] = num;
        return nums;
    }
}
using System;

public class Solution {
    public int[] SortJumbled(int[] mapping, int[] nums) {
        int[] mappedValues = GetMappedValues(mapping, nums);
        return SortByMappedValues(nums, mappedValues);
    }
    private int[] GetMappedValues(int[] mapping, int[] nums) {
        int[] mappedValues = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++) {
            mappedValues[i] = MapValue(mapping, nums[i]);
        }
        return mappedValues;
    }
    private int MapValue(int[] mapping, int num) {
        char[] digits = num.ToString().ToCharArray();
        for (int i = 0; i < digits.Length; i++) {
            digits[i] = (char)(mapping[digits[i] - '0'] + '0');
        }
        return int.Parse(new string(digits));
    }
    private int[] SortByMappedValues(int[] nums, int[] mappedValues) {
        int[][] paired = new int[nums.Length][];
        for (int i = 0; i < nums.Length; i++) {
            paired[i] = new int[] { nums[i], mappedValues[i] };
        }
        Array.Sort(paired, (a, b) => a[1] == b[1] ? 0 : a[1].CompareTo(b[1]));
        for (int i = 0; i < nums.Length; i++) {
            nums[i] = paired[i][0];
        }
        return nums;
    }
}
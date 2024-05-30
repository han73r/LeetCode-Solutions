using System.Collections.Generic;
using System;

public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
        IList<int> result = new List<int>();
        for (int i = 0; i < nums.Length; i++) {
            int index = Math.Abs(nums[i]) - 1;

            if (nums[index] < 0) {
                result.Add(index + 1);
            } else {
                nums[index] = -nums[index];
            }
        }
        for (int i = 0; i < nums.Length; i++) {
            nums[i] = Math.Abs(nums[i]);
        }
        return result;
    }
}
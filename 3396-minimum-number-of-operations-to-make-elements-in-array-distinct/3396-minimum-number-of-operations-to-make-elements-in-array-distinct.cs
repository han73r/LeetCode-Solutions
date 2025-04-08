using System.Collections.Generic;

public class Solution {
    public int MinimumOperations(int[] nums) {
        var operation = 0;
        var set = new HashSet<int>();
        for (int j = nums.Length - 1; j >= 0; j--) {
            if (!set.Contains(nums[j]))
                set.Add(nums[j]);
            else
                return (j + 3) / 3;
        }
        return 0;
    }
}
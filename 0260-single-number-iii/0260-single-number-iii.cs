using System.Collections.Generic;
public class Solution {
    public int[] SingleNumber(int[] nums) {
        HashSet<int> set = new HashSet<int>();
        int l = nums.Length;
        for (int i = 0; i < l; i++) {
            if (set.Contains(nums[i])) {
                set.Remove(nums[i]);
            } else {
                set.Add(nums[i]);
            }
        }
        return set.ToArray();
    }
}
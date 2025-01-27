using System.Collections.Generic;

// Sort + 2 pointers. Time: O(n log n). Space: O(1)
public class Solution {
    public int CountPairs(IList<int> nums, int target) {
        if (nums.Count == 1) return 0;
        nums = nums.OrderBy(x => x).ToList();
        int count = 0;
        int left = 0, right = nums.Count - 1;
        while (left < right) {
            if (nums[left] + nums[right] < target) {
                count += (right - left);
                left++;
            } else {
                right--;
            }
        }
        return count;
    }
}
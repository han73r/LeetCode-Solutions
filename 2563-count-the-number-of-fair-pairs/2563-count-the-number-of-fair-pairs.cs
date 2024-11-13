public class Solution {
    public long CountFairPairs(int[] nums, int lower, int upper) {
        Array.Sort(nums);
        long countPairsInRange(int target) {
            int left = 0, right = nums.Length - 1;
            long count = 0;
            while (left < right) {
                if (nums[left] + nums[right] <= target) {
                    count += right - left;
                    left++;
                } else {
                    right--;
                }
            }
            return count;
        }
        return countPairsInRange(upper) - countPairsInRange(lower - 1);
    }
}
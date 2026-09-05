public class Solution {
    public int FirstStableIndex(int[] nums, int k) {
        int n = nums.Length;
        int[] minval = new int[n];
        int curMax = nums[0];
        minval[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--) {
            minval[i] = Math.Min(nums[i], minval[i + 1]);
        }
        for (int i = 0; i < n; i++) {
            curMax = Math.Max(curMax, nums[i]);
            if (curMax - minval[i] <= k) {
                return i;
            }
        }
        return -1;
    }
}

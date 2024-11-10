public class Solution {
    public int MinimumSubarrayLength(int[] nums, int k) {
        int min = nums.Length + 1;
        for (int i = 0; ; i++) {
            for (int o = 0; i < nums.Length; i++) {
                o |= nums[i];
                if (o >= k) break;
            }
            if (i >= nums.Length) return min > nums.Length ? -1 : min;
            for (int len = 0, o = 0; ++len < min; i--) {
                o |= nums[i];
                if (o >= k) { min = len; break; }
            }
            if (min == 1) return 1;
        }
    }
}
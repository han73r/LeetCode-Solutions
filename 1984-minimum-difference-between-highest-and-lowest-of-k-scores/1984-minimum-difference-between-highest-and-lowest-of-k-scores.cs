public class Solution {
    public int MinimumDifference(int[] nums, int k) {
        Array.Sort(nums);
        int ans = int.MaxValue, j = k - 1;
        for(int i = 0; i + j < nums.Length; i++)
            ans = Math.Min(ans, nums[i + j] - nums[i]);
        return ans;
    }
}

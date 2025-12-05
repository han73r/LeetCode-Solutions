public class Solution {
    public int CountPartitions(int[] nums) {
        int total = 0;
        foreach (int x in nums) total += x;
        int left = 0, ans = 0;
        for (int i = 0; i < nums.Length - 1; i++) {
            left += nums[i];
            int right = total - left;
            if (((left - right) & 1) == 0) ans++;
        }
        return ans;
    }
}

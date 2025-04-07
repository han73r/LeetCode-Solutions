using System.Linq;

public class Solution {
    public bool CanPartition(int[] nums) {
        int sum = nums.Sum();
        if (sum % 2 != 0) return false;
        int target = sum / 2;
        bool[] dp = new bool[target + 1];
        dp[0] = true;
        foreach (var num in nums) {
            for (int j = target; j >= num; j--) {
                dp[j] = dp[j] || dp[j - num];
            }
        }
        return dp[target];
    }
}
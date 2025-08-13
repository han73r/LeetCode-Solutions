public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {
        int sum = 0; 
        var length = nums.Length; // [1,1,1,1,1]
        for (int i = 0; i < length; i++)
            sum += nums[i]; // 5
    // can we achive?
        if ((target + sum) % 2 != 0 || Math.Abs(target) > sum)  
            return 0;
        int subsetSumTarget = (target + sum) / 2;
        if (subsetSumTarget < 0 || subsetSumTarget > sum)
            return 0;

        int[] dp = new int[subsetSumTarget + 1];
        dp[0] = 1;

        for (int i = 0; i < length; i++)
            for (int j = subsetSumTarget; j >=  nums[i]; j--)
                dp[j] += dp[j -  nums[i]];

        return dp[subsetSumTarget];
    }
}
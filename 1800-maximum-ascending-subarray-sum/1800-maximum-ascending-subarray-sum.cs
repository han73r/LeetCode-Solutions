public class Solution {
    public int MaxAscendingSum(int[] nums) {
        int maxPossibleSum = nums[0];
        int currentCount = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] > nums[i - 1])
                currentCount += nums[i];
            else
                currentCount = nums[i];  
            maxPossibleSum = Math.Max(maxPossibleSum, currentCount);
        }
        return maxPossibleSum;
    }
}
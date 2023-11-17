public class Solution
{
    public int MinPairSum(int[] nums)
    {
        int n = nums.Length;
        int maxPairSum = int.MinValue;
        Array.Sort(nums);

        for (int i = 0; i < n / 2; i++)
        {
            int currentPairSum = nums[i] + nums[n - i - 1];
            maxPairSum = Math.Max(maxPairSum, currentPairSum);
        }

        return maxPairSum;
    }
}
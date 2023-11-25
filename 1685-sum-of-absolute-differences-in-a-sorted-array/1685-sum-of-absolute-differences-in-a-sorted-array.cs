public class Solution
{
    public int[] GetSumAbsoluteDifferences(int[] nums)
    {
        int n = nums.Length;
        int[] prefixSum = new int[n];
        int[] suffixSum = new int[n];

        // Calculate prefix sum
        prefixSum[0] = nums[0];
        for (int i = 1; i < n; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + nums[i];
        }

        // Calculate suffix sum
        suffixSum[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            suffixSum[i] = suffixSum[i + 1] + nums[i];
        }

        int[] result = new int[n];

        // Calculate result using prefixSum and suffixSum
        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                result[i] = (suffixSum[i + 1] - (n - 1) * nums[i]);
            }
            else if (i == n - 1)
            {
                result[i] = (n - 1) * nums[i] - prefixSum[i - 1];
            }
            else
            {
                result[i] = (i * nums[i] - prefixSum[i - 1]) + ((suffixSum[i + 1] - (n - i - 1) * nums[i]));
            }
        }
        return result;
    }
}
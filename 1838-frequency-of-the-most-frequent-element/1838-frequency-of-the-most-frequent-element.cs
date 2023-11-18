public class Solution
{
    public int MaxFrequency(int[] nums, int k)
    {
        Array.Sort(nums);
        int left = 0;
        long sum = 0;
        int result = 1;
        for (int right = 0; right < nums.Length; right++)
        {
            sum += nums[right];
            while ((long)nums[right] * (right - left + 1) - sum > k)
            {
                sum -= nums[left];
                left++;
            }
            result = Math.Max(result, right - left + 1);
        }
        return result;
    }
}
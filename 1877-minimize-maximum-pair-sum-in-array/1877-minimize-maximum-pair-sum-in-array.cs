public class Solution
{
    public int MinPairSum(int[] nums)
    {
        var k = nums.Length;
        var sum = new int[k / 2];
        Array.Sort(nums);

        for (int i = 0; i < k / 2; i++)
        {
            sum[i] = nums[i] + nums[k - i - 1];
        }

        return sum.Max();
    }
}
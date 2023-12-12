public class Solution
{
    public int MaxProduct(int[] nums)
    {
        int length = nums.Length;
        if (length == 2)
        {
            return (nums[0] - 1) * (nums[1] - 1);
        }
        Array.Sort(nums);
        return (nums[length - 1] - 1) * (nums[length - 2] - 1);
    }
}
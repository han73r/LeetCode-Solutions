public class Solution
{
    public int ReductionOperations(int[] nums)
    {
        Array.Sort(nums);
        int operations = 0;
        int max = nums[nums.Length - 1];

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            if (nums[i] < max)
            {
                max = nums[i];
                operations += nums.Length - i - 1;
            }
        }
        return operations;
    }
}
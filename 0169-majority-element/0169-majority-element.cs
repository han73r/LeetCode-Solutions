public class Solution 
{
    public int MajorityElement(int[] nums)
    {
        int size = nums.Length;
        if (size == 1) { return nums[0]; }
        if (size == 2 && nums[0] == nums[1]) { return nums[0]; }

        // Boyer–Moore algorithm
        // Start from: first element == majority
        int majority = nums[0];
        int count = 1;

        for (int i = 1; i < size; i++)
        {
            if (count == 0)
            {
                majority = nums[i];
                count = 1;
            }
            else if (nums[i] == majority)
            {
                count++;
            }
            else
            {
                count--;
            }
        }
        return majority;
    }
}
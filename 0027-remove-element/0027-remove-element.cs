public class Solution 
{
    public int RemoveElement(int[] nums, int val) 
    {
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[count] = nums[i];
                count++;
            }
        }

        // for (int i = count; i < nums.Length; i++)
        // {
        //     nums[i] = 0;
        // }

        return count;
    }
}
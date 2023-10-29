public class Solution 
{
    public int SearchInsert(int[] nums, int target) 
    {
        int maxIndex = nums.Length;
        if (nums.Length == 0) { return 0; }

        for (int i = 0; i < maxIndex; i++)
        {
            if (nums[i] >= target)
            {
                return i;
            }
        }
        return maxIndex;
    }
}

public class Solution 
{
    public int RemoveDuplicates(int[] nums)
    {
        int k = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if(i == 0 || nums[i] != nums[i-1])
            {
                nums[k] = nums[i];
                k++;
            }
            
        }

        // for (int i = k; i < nums.Length; i++)
        // {
        //     nums[i] = 0;
        // }

        return k;
    }
}
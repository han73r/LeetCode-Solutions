public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> numToIndex = new Dictionary<int, int>();
        
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            
            if (numToIndex.ContainsKey(complement))
            {
                return new int[] { numToIndex[complement], i };
            }
            
            if (!numToIndex.ContainsKey(nums[i]))
            {
                numToIndex[nums[i]] = i;
            }
        }
        
        return null;
    }
}
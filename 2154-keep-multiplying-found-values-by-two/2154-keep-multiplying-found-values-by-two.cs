public class Solution {
    public int FindFinalValue(int[] nums, int original) 
        => nums.Contains(original) ? FindFinalValue(nums, original * 2) : original;
}

public class Solution {
    public int SubsetXORSum(int[] nums) {
        return GetSubsetXORSum(nums, 0, 0);
    }
    private int GetSubsetXORSum(int[] nums, int index, int xorTotal) {
        if (index == nums.Length) return xorTotal;
        int includeCurrent = GetSubsetXORSum(nums, index + 1, xorTotal ^ nums[index]);
        int excludeCurrent = GetSubsetXORSum(nums, index + 1, xorTotal);
        return includeCurrent + excludeCurrent;
    }
}
public class Solution {
    public int MinOperations(int[] nums, int k) {
        int sum = 0, n = nums.Length;
        for(int i = 0; i < n; i++)
            sum += nums[i];
        return sum % k;
    }
}

public class Solution {
    public int MinimumOperations(int[] nums) {
        int operations = 0;
        var n = nums.Length;
        for (int i = 0; i < n; i++) {
            if (nums[i] % 3 != 0)
                operations++;
        }
        return operations;
    }
}

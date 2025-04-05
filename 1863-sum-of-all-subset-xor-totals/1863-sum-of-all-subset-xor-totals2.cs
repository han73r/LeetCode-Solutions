public class Solution {
    public int SubsetXORSum(int[] nums) {
        int n = nums.Length;
        int sum = 0;
        int subsets = 1 << n;
        for (int i = 0; i < subsets; i++) {
            int xor = 0;
            for (int j = 0; j < n; j++) {
                if ((i & (1 << j)) != 0)
                    xor ^= nums[j];
            }
            sum += xor;
        }
        return sum;
    }
}
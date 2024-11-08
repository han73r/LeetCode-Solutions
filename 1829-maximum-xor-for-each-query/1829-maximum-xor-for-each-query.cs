public class Solution {
    public int[] GetMaximumXor(int[] nums, int maximumBit) {
        int mask = (1 << maximumBit) - 1;
        int l = nums.Length;
        int[] result = new int[l];
        int curr = 0;
        for (int i = 0; i < l; i++) {
            curr ^= nums[i];
            result[l - i - 1] = ~curr & mask;
        }
        return result;
    }
}
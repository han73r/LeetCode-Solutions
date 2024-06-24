public class Solution {
    public int MinKBitFlips(int[] nums, int k) {
        int n = nums.Length;
        int[] flip = new int[n];
        int flips = 0;
        int flipState = 0;
        for (int i = 0; i < n; i++) {
            if (i >= k) {
                flipState ^= flip[i - k];
            }
            if (nums[i] == flipState) {
                if (i + k > n) {
                    return -1;
                }
                flipState ^= 1;
                flip[i] = 1;
                flips++;
            }
        }
        return flips;
    }
}
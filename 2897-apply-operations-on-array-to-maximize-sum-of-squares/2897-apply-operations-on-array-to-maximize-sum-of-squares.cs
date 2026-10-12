public class Solution {
    private const int Mod = 1_000_000_007;
    private const int BitLength = 30; // (2^30 ≈ 1.07 * 10^9)

    public int MaxSum(IList<int> nums, int k) {
        int[] counts = new int[BitLength];

        foreach (int num in nums) {
            for (int i = 0; i < BitLength; i++) {
                if ((num & (1 << i)) != 0) {
                    counts[i]++;
                }
            }
        }

        long res = 0;
        for (int i = 0; i < k; i++) {
            long cur = 0;
            for (int j = BitLength - 1; j >= 0; j--) {
                if (counts[j] > 0) {
                    cur |= (1L << j);
                    counts[j]--;
                }
            }
            res = (res + cur * cur) % Mod;
        }

        return (int)res;
    }
}

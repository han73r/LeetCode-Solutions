public class Solution {
    public int MaximumElementAfterDecrementingAndRearranging(int[] arr) {
        int res = 0;
        int n = arr.Length;
        int[] counts = new int[n + 1];

        foreach (int num in arr) {
            counts[Math.Min(num, n)]++;
        }

        for (int i = 1; i <= n; i++) {
            if (counts[i] != 0) {
                if (i > res) {
                    res += Math.Min(i - res, counts[i]);
                } else {
                    res++;
                }
            }
        }

        return res;
    }
}

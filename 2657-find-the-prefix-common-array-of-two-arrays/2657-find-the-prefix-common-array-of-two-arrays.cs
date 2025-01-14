public class Solution {
    public int[] FindThePrefixCommonArray(int[] A, int[] B) {
        int l = A.Length;
        int[] freq = new int[l + 1];
        int[] ans = new int[l];
        int common = 0;
        for (int i = 0; i < l; i++) {
            if (++freq[A[i]] == 2) common++;
            if (++freq[B[i]] == 2) common++;
            ans[i] = common;
        }
        return ans;
    }
}
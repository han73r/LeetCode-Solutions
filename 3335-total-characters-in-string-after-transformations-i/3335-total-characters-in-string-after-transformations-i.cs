public class Solution {
    const int MOD = 1_000_000_007;
    public int LengthAfterTransformations(string s, int t) {
        long[,] dp = new long[26, t + 1];
        for (int i = 0; i < 26; i++)
            dp[i, 0] = 1;
        for (int i = 1; i <= t; i++) {
            for (int j = 0; j < 26; j++) {
                if (j == 25)
                    dp[j, i] = (dp[0, i - 1] + dp[1, i - 1]) % MOD;
                else
                    dp[j, i] = dp[j + 1, i - 1];
            }
        }
        long result = 0;
        foreach (char c in s) {
            int idx = c - 'a';
            result = (result + dp[idx, t]) % MOD;
        }
        return (int)result;
    }
}
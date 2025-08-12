public class Solution {
    const int MOD = 1_000_000_007;
    List<int> P = new List<int>();
    Dictionary<(int i,int t), int> memo = new();

    public int NumberOfWays(int n, int x) {
        for (int b = 1; ; b++) {              // candidates ≤ n
            double val = Math.Pow(b, x);
            if (val > n) break;
            P.Add((int)val);
        }
        memo.Clear();
        return Ways(0, n);
    }

    int Ways(int i, int target) {
        if (target == 0) return 1;
        if (target < 0 || i >= P.Count) return 0;

        var key = (i, target);
        if (memo.TryGetValue(key, out int got)) return got; // ① check

        long take = Ways(i + 1, target - P[i]);             // ② work
        long skip = Ways(i + 1, target);
        int ans = (int)((take + skip) % MOD);

        memo[key] = ans;                                     // ③ store
        return ans;
    }
}
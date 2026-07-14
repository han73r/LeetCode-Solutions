public class Solution {
    const long MOD = 1000000007;
    private int[] nums;
    private Dictionary<(int, int, int), long> memo;

    public int SubsequencePairCount(int[] nums) {
        this.nums = nums;
        memo = new Dictionary<(int, int, int), long>();
        return (int)((Dfs(0, 0, 0) - 1 + MOD) % MOD);
    }

    private long Dfs(int i, int a, int b) {
        if (i == nums.Length) {
            return a == b ? 1 : 0;
        }

        var key = (i, a, b);
        if (memo.TryGetValue(key, out long res)) {
            return res;
        }

        res = 0;

        // Do not take
        res += Dfs(i + 1, a, b);

        // Take into A
        res += Dfs(i + 1, Gcd(a, nums[i]), b);

        // Take into B
        res += Dfs(i + 1, a, Gcd(b, nums[i]));

        return memo[key] = res % MOD;
    }

    private int Gcd(int a, int b) {
        while (b != 0) {
            int t = a % b;
            a = b;
            b = t;
        }

        return a;
    }
}

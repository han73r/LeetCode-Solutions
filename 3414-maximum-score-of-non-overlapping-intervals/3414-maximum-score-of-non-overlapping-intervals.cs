public class Solution {
    public int[] MaximumWeight(IList<IList<int>> I) {
        int n = I.Count;
        var A = I.Select((v, i) => (l: (long)v[0], r: (long)v[1], w: (long)v[2], id: i))
                 .OrderBy(x => x.l).ThenBy(x => x.r).ThenBy(x => x.id).ToArray();
        var S = A.Select(x => x.l).ToArray();
        var dp = new (long w, List<int> ids)[n + 1, 5];

        for (int i = 0; i <= n; i++) for (int k = 0; k <= 4; k++) dp[i, k] = (0, new List<int>());

        Func<List<int>, List<int>, bool> isLex = (a, b) => {
            if (b.Count == 0) return true;

            for (int j = 0; j < Math.Min(a.Count, b.Count); j++) {
                if (a[j] != b[j]) return a[j] < b[j];
            }
            
            return a.Count < b.Count;
        };

        for (int i = n - 1; i >= 0; i--) {
            int low = 0, high = n;

            while (low < high) { int m = (low + high) / 2; if (S[m] > A[i].r) high = m; else low = m + 1; }

            for (int k = 1; k <= 4; k++) {
                var best = dp[i + 1, k];
                var prev = dp[low, k - 1];
                var tids = new List<int>(prev.ids) { A[i].id }; tids.Sort();
                long tw = prev.w + A[i].w;

                bool better = tw > best.w || (tw == best.w && isLex(tids, best.ids));
                dp[i, k] = better ? (tw, tids) : best;
            }
        }

        return dp[0, 4].ids.ToArray();
    }
}

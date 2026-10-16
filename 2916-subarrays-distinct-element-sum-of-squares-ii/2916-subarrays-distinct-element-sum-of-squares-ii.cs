public class Solution {
    private const long Mod = 1_000_000_007;
    private const int DictSize = 100_005;

    public int SumCounts(IList<int> nums) {
        int n = nums.Count;
        LazySegmentTree tree = new LazySegmentTree(n);
        int[] lastSeen = new int[DictSize];
        Array.Fill(lastSeen, -1);
        long totalAns = 0;

        for (int r = 0; r < n; r++) {
            int x = nums[r];
            int l = lastSeen[x] != -1 ? lastSeen[x] + 1 : 0;
            
            tree.Update(0, 0, n - 1, l, r, 1);
            lastSeen[x] = r;
            
            totalAns = (totalAns + tree.GetTotalSumSq()) % Mod;
        }

        return (int)totalAns;
    }

    private class LazySegmentTree {
        private readonly long[] sum;
        private readonly long[] sumSq;
        private readonly long[] lazy;

        public LazySegmentTree(int n) {
            sum = new long[4 * n];
            sumSq = new long[4 * n];
            lazy = new long[4 * n];
        }

        public long GetTotalSumSq() {
            return sumSq[0];
        }

        private void Push(int node, int start, int end) {
            if (lazy[node] == 0) return;

            long val = lazy[node];
            int mid = start + (end - start) / 2;
            int leftChild = 2 * node + 1;
            int rightChild = 2 * node + 2;

            Apply(leftChild, start, mid, val);
            Apply(rightChild, mid + 1, end, val);

            lazy[node] = 0;
        }

        private void Apply(int node, int start, int end, long val) {
            long len = end - start + 1;
            sumSq[node] = (sumSq[node] + 2 * val % Mod * sum[node] % Mod + len * val % Mod * val % Mod) % Mod;
            sum[node] = (sum[node] + len * val % Mod) % Mod;
            lazy[node] = (lazy[node] + val) % Mod;
        }

        public void Update(int node, int start, int end, int l, int r, long val) {
            if (r < start || end < l) return;

            if (l <= start && end <= r) {
                Apply(node, start, end, val);
                return;
            }

            Push(node, start, end);

            int mid = start + (end - start) / 2;
            Update(2 * node + 1, start, mid, l, r, val);
            Update(2 * node + 2, mid + 1, end, l, r, val);

            sum[node] = (sum[2 * node + 1] + sum[2 * node + 2]) % Mod;
            sumSq[node] = (sumSq[2 * node + 1] + sumSq[2 * node + 2]) % Mod;
        }
    }
}

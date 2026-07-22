public class Solution {
    public List<int> MaxActiveSectionsAfterTrade(string s, int[][] queries) {
        int n = s.Length, m = queries.Length;
        int cnt1 = 0;
        foreach (char c in s) {
            if (c == '1') {
                cnt1++;
            }
        }

        int[] left = new int[n];
        int[] right = new int[n];

        for (int i = 0; i < n; i++) {
            left[i] = (i > 0 && s[i - 1] == s[i]) ? left[i - 1] + 1 : 1;
        }
        for (int i = n - 1; i >= 0; i--) {
            right[i] = (i < n - 1 && s[i + 1] == s[i]) ? right[i + 1] + 1 : 1;
        }

        List<int> ans = new List<int>(new int[m]);
        for (int i = 0; i < m; i++) {
            ans[i] = -1;
        }

        int block_size = (int)Math.Sqrt(n);
        List<(int bid, int l, int r, int qid)> longQueries = new List<(int, int, int, int)>();

        for (int i = 0; i < m; i++) {
            int l = queries[i][0], r = queries[i][1];
            if (r - l + 1 > block_size) {
                longQueries.Add((l / block_size, l, r, i));
            } else {
                ans[i] = cnt1 + BruteForce(s, l, r);
            }
        }

        longQueries.Sort((a, b) => {
            if (a.bid != b.bid)
                return a.bid.CompareTo(b.bid);
            return a.r.CompareTo(b.r);
        });

        LinkedList<int> subZeroBlocks = new LinkedList<int>();
        int L = 0, R = 0, bestGain = 0;

        for (int i = 0; i < longQueries.Count; i++) {
            var (bid, l, r, qid) = longQueries[i];

            if (i == 0 || bid > longQueries[i - 1].bid) {
                L = (bid + 1) * block_size - 1;
                R = (bid + 1) * block_size;
                subZeroBlocks.Clear();
                bestGain = 0;
            }

            while (R <= r) {
                int sz = Math.Min(r - R + 1, right[R]);
                if (s[R] == '0') {
                    if (subZeroBlocks.Count > 0 && s[R - 1] == '0') {
                        subZeroBlocks.Last.Value += sz;
                    } else {
                        subZeroBlocks.AddLast(sz);
                    }
                    if (subZeroBlocks.Count >= 2) {
                        bestGain = Math.Max(subZeroBlocks.Last.Value + subZeroBlocks.Last.Previous.Value, bestGain);
                    }
                }
                R += sz;
            }

            int tmp_bestGain = bestGain;
            int tmp_firstValue = subZeroBlocks.Count == 0 ? -1 : subZeroBlocks.First.Value;
            int cnt = 0;

            while (L >= l) {
                int sz = Math.Min(L - l + 1, left[L]);
                if (s[L] == '0') {
                    if (subZeroBlocks.Count > 0 && s[L + 1] == '0') {
                        subZeroBlocks.First.Value += sz;
                    } else {
                        subZeroBlocks.AddFirst(sz);
                        cnt++;
                    }
                    if (subZeroBlocks.Count >= 2) {
                        bestGain = Math.Max(subZeroBlocks.First.Value + subZeroBlocks.First.Next.Value, bestGain);
                    }
                }
                L -= sz;
            }

            ans[qid] = bestGain + cnt1;
            L = (bid + 1) * block_size - 1;
            bestGain = tmp_bestGain;

            for (int j = 0; j < cnt; j++) {
                subZeroBlocks.RemoveFirst();
            }
            if (tmp_firstValue != -1) {
                subZeroBlocks.First.Value = tmp_firstValue;
            }
        }

        return ans;
    }

    private int BruteForce(string s, int l, int r) {
        int i = l;
        int best = 0;
        int prev = int.MinValue;

        while (i <= r) {
            int start = i;
            while (i <= r && s[i] == s[start]) {
                i++;
            }
            if (s[start] == '0') {
                int cur = i - start;
                if (prev != int.MinValue && prev + cur > best) {
                    best = prev + cur;
                }
                prev = cur;
            }
        }

        return best;
    }
}

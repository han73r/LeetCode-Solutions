public class Solution {
    public int[] GcdValues(int[] nums, long[] queries) {
        int m = 0;

        foreach (int x in nums)
            if (x > m)
                m = x;

        long[] cnt = new long[m + 1];

        foreach (int x in nums)
            cnt[x]++;

        for (int i = 1; i <= m; i++)
            for (int j = i << 1; j <= m; j += i)
                cnt[i] += cnt[j];

        for (int i = 1; i <= m; i++) {
            long c = cnt[i];
            cnt[i] = c * (c - 1) / 2;
        }

        for (int i = m; i >= 1; i--)
            for (int j = i << 1; j <= m; j += i)
                cnt[i] -= cnt[j];

        for (int i = 1; i <= m; i++)
            cnt[i] += cnt[i - 1];

        int[] ans = new int[queries.Length];

        for (int k = 0; k < queries.Length; k++) {
            long target = queries[k] + 1;

            int left = 1;
            int right = m;

            while (left < right) {
                int mid = (left + right) >> 1;

                if (cnt[mid] >= target)
                    right = mid;
                else
                    left = mid + 1;
            }

            ans[k] = left;
        }

        return ans;
    }
}

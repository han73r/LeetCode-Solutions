class Solution {
    int[][] events;
    int[,] memo;
    int n;

    public int MaxValue(int[][] events, int k) {
        this.events = events;
        n = events.Length;
        Array.Sort(events, (a, b) => a[0] - b[0]);
        memo = new int[n, k + 1];
        for (int i = 0; i < n; i++)
            for (int j = 0; j <= k; j++)
                memo[i, j] = -1;
        return DFS(0, k);
    }

    int DFS(int i, int k) {
        if (i == n || k == 0) return 0;
        if (memo[i, k] != -1) return memo[i, k];
        int skip = DFS(i + 1, k);
        int nextIndex = NextEventIndex(events[i][1]);
        int take = events[i][2] + (nextIndex == -1 ? 0 : DFS(nextIndex, k - 1));
        memo[i, k] = Math.Max(skip, take);
        return memo[i, k];
    }

    int NextEventIndex(int endTime) {
        int left = 0, right = n - 1, ans = -1;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (events[mid][0] > endTime) {
                ans = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        return ans;
    }
}
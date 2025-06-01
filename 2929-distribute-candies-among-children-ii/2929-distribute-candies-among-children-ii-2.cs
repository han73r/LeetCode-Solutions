public class Solution {
    public long DistributeCandies(int n, int limit) {
        return Cal(n + 2) - 3 * Cal(n - limit + 1) +
               3 * Cal(n - (limit + 1) * 2 + 2) - Cal(n - 3 * (limit + 1) + 2);
    }
    public long Cal(int x) {
        if (x < 0)
            return 0;
        return (long)x * (x - 1) / 2;
    }
}
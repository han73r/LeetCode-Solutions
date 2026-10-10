public class Solution {
    public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2) {
        var n = nums1.Length;
        var diffCounts = new Dictionary<int, int>();
        long totalK = (long)k1 + k2;
        long totalDiffSum = 0;
        int maxDiff = 0;

        for (int i = 0; i < n; i++) {
            int diff = Math.Abs(nums1[i] - nums2[i]);
            if (diff > 0) {
                diffCounts[diff] = diffCounts.GetValueOrDefault(diff, 0) + 1;
                totalDiffSum += diff;
                maxDiff = Math.Max(maxDiff, diff);
            }
        }

        if (totalDiffSum <= totalK)
            return 0;

        for (int d = maxDiff; d > 0 && totalK > 0; d--) {

            if (!diffCounts.TryGetValue(d, out var count) || count == 0)
                continue;

            long reduceCount = Math.Min(totalK, count);
            long nextD = d - 1;
            diffCounts[d] = count - (int)reduceCount;

            if (nextD > 0)
                diffCounts[(int)nextD] = diffCounts.GetValueOrDefault((int)nextD, 0) + (int)reduceCount;

            totalK -= reduceCount;
        }

        long minSumSq = 0;
        
        foreach (var pair in diffCounts)
            minSumSq += (long)pair.Key * pair.Key * pair.Value;

        return minSumSq;
    }
}

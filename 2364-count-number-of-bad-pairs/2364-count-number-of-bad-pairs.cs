public class Solution {
    public long CountBadPairs(int[] nums) {
        int n = nums.Length;
        long totalPairs = (long)n * (n - 1) / 2;
        long goodPairs = 0;
        var freq = new Dictionary<int, int>();
        for (int i = 0; i < n; i++) {
            int key = nums[i] - i;
            if (freq.ContainsKey(key)) {
                goodPairs += freq[key];
                freq[key]++;
            } else {
                freq[key] = 1;
            }
        }
        return totalPairs - goodPairs;
    }
}
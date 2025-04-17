public class Solution {
    public int CountPairs(int[] nums, int k) {
        var dict = new Dictionary<int, List<int>>();
        int n = nums.Length;
        int result = 0;
        for (int i = 0; i < n; i++) {
            if (dict.ContainsKey(nums[i]))
                dict[nums[i]].Add(i);
            else
                dict[nums[i]] = new List<int> { i };
        }
        foreach (var entry in dict) {
            var indices = entry.Value;
            if (indices.Count < 2) continue;
            for (int i = 0; i < indices.Count; i++) {
                for (int j = i + 1; j < indices.Count; j++) {
                    if (IsValidPair(indices[i], indices[j], k))
                        result++;
                }
            }
        }
        return result;
    }

    private bool IsValidPair(int i, int j, int k) {
        return (i * j) % k == 0;
    }
        
}
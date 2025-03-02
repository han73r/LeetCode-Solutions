public class Solution {
    public int[][] MergeArrays(int[][] nums1, int[][] nums2) {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        foreach (var num in nums1)
            dict[num[0]] = num[1];
        foreach (var num in nums2) {
            if (dict.ContainsKey(num[0]))
                dict[num[0]] += num[1];
            else
                dict[num[0]] = num[1];
        }
        var result = new List<int[]>();
        foreach (var kv in dict.OrderBy(x => x.Key))
            result.Add(new int[] { kv.Key, kv.Value });

        return result.ToArray();
    }
}
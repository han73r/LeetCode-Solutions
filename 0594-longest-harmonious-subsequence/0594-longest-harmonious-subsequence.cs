using System.Linq;

public class Solution {
    public int FindLHS(int[] nums) {
        var freq = nums.GroupBy(n => n)
                    .ToDictionary(g => g.Key, g => g.Count());
        return freq.Where(kvp => freq.ContainsKey(kvp.Key + 1))
                .Select(kvp => kvp.Value + freq[kvp.Key + 1])
                .DefaultIfEmpty(0)
                .Max();
    }
}
public class Solution {
    public int SumCounts(IList<int> nums) =>
        Enumerable.Range(0, nums.Count)
            .SelectMany(i => Enumerable.Range(1, nums.Count - i), (i, len) => new { i, len })
            .Sum(x => (int)Math.Pow(new HashSet<int>(nums.Skip(x.i).Take(x.len)).Count, 2));
}

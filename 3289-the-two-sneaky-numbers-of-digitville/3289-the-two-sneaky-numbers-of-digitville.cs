public class Solution {
    public int[] GetSneakyNumbers(int[] nums) {
        return nums
            .GroupBy(x => x)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToArray();
    }
}

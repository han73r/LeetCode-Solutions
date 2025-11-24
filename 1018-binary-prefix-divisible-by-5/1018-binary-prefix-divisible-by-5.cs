public class Solution {
    public IList<bool> PrefixesDivBy5(int[] nums) {
        var result = new List<bool>(nums.Length);
        int remainder = 0;
        foreach (var bit in nums) {
            remainder = (remainder * 2 + bit) % 5;
            result.Add(remainder == 0);
        }
        return result;
    }
}

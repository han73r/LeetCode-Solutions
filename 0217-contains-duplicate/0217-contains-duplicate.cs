public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        var freq = new HashSet<int>();
        foreach (int num in nums) {
            if (freq.Contains(num)) return true;
            freq.Add(num);
        }
        return false;
    }
}

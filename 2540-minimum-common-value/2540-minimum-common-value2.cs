public class Solution {
    public int GetCommon(int[] nums1, int[] nums2) {
        HashSet<int> set = new();
        int minCommon = Int32.MaxValue;
        foreach (int num in nums1) {
            set.Add(num);
        }
        foreach (int num in nums2) {
            if (set.Contains(num))
                minCommon = Math.Min(minCommon, num);
        }
        return minCommon == Int32.MaxValue ? -1 : minCommon;
    }
}

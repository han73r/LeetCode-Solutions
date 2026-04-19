public class Solution {
    public int MaxDistance(int[] nums1, int[] nums2) {
        int nums1Length = nums1.Length;
        int nums2Length = nums2.Length;
        int i = 0, j = 0;
        int max = 0;
        while (i < nums1Length && j < nums2Length) {
            if (nums1[i] <= nums2[j]) {
                max = Math.Max(max, j - i);
                j++;
            } else {
                i++;
            }
        }
        return max;
    }
}

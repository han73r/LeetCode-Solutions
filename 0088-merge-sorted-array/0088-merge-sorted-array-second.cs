public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int firstIndex = m - 1, secondIndex = n - 1, lastIndex = nums1.Length - 1;
        while (firstIndex >= 0 && secondIndex >= 0) {
            if (nums1[firstIndex] > nums2[secondIndex]) {
                nums1[lastIndex] = nums1[firstIndex];
                firstIndex -= 1;
            } else {
                nums1[lastIndex] = nums2[secondIndex];
                secondIndex -= 1;
            }
            lastIndex -= 1;
        }
        while (secondIndex >= 0) {
            nums1[lastIndex] = nums2[secondIndex];
            lastIndex -= 1;
            secondIndex -= 1;
        }
    }
}
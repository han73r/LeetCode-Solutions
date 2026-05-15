public class Solution {
    public int FindMin(int[] nums) {
        int l = 0, r = nums.Length - 1;
        while (l < r) {
            int mid = (l + r) >> 1;
            if (nums[r] > nums[mid]) {
                r = mid;
            } else {
                l = mid + 1;
            }
        }
        return nums[l];
    }
}

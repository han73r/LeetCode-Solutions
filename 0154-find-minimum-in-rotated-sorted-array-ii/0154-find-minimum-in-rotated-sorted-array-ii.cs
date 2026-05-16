public class Solution {
    public int FindMin(int[] nums) {
        int left = 0, right = nums.Length - 1;
        while (left < right) {
            if (nums[left] < nums[right])
                return nums[left];
            int mid = left + (right - left) / 2;
            if (nums[mid] == nums[right] && nums[mid] == nums[left]) {
                int min = nums[mid];
                while (right != mid) {
                    min = Math.Min(min, nums[--right]);
                    min = Math.Min(min, nums[++left]);
                }
                return min;
            }
            else if (nums[mid] > nums[right]) left = mid + 1;
            else right = mid;
        }
        return nums[left];
    }
}

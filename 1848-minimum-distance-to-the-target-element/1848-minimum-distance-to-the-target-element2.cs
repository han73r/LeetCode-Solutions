public class Solution {
    public int GetMinDistance(int[] nums, int target, int start) {
        int n = nums.Length;
        int left = 0, right = 0;
        for (int i = 0; ;i++) {
            left = start - i;
            right = start + i;
            if (left >= 0 && nums[left] == target) return i;
            if (right < n && nums[right] == target) return i;
        }
    }
}

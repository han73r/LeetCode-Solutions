public class Solution {
    public int NumSubarrayProductLessThanK(int[] nums, int k) {
        int count = 0, product = 1, left = 0;
        for (int right = 0; right < nums.Length; right++) {
            product *= nums[right];
            while (left <= right && product >= k) {
                product /= nums[left];
                left++;
            }
            count += right - left + 1;
        }
        return count;
    }
}
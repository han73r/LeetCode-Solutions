public class Solution {
    public void SortColors(int[] nums) {
        int left = 0, mid = 0;
        int right = nums.Length - 1;
        while (mid <= right) {
            if (nums[mid] == 0) {
                Swap(nums, left, mid);
                left++;
                mid++;
            } else if (nums[mid] == 1) {
                mid++;
            } else {
                Swap(nums, mid, right);
                right--;
            }
        }
    }
    private void Swap(int[] nums, int i, int j) {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}
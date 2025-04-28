public class Solution {
    public int RemoveDuplicates(int[] nums) {
        var n = nums.Length;
        if (n == 1) return n;
        int left = 0, right = 1;
        while (right < n) {
            if (nums[left] != nums[right]) {
                left++;
                nums[left] = nums[right];
            }
            right++;
        }
        return left + 1;
    }
}
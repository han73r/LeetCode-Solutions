public class Solution {
    public static readonly int RATE = 2;
    public int RemoveDuplicates(int[] nums) {
        if (nums.Length <= RATE) return nums.Length;
        int left = RATE;
        for (int right = RATE; right < nums.Length; right++) {
            if (nums[right] != nums[left - RATE]) {
                nums[left] = nums[right];
                left++;
            }
        }
        return left;
    }
}
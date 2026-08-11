public class Solution {
    public int MissingInteger(int[] nums) {
        int sum = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] == nums[i - 1] + 1) {
                sum += nums[i];
            } else {
                break;
            }
        }
        while (Array.Exists(nums, x => x == sum)) {
            sum++;
        }
        return sum;
    }
}

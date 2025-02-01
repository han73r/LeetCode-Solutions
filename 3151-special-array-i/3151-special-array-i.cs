public class Solution {
    public bool IsArraySpecial(int[] nums) {
        int length = nums.Length - 1;
        for (int i = 0; i < length; i++)
            if ((nums[i] + nums[i + 1]) % 2 == 0) return false;
        return true;
    }
}
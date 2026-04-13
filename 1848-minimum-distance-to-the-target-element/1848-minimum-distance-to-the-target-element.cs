public class Solution {
    public int GetMinDistance(int[] nums, int target, int start) {
        int n = nums.Length;
        int result = int.MaxValue;
        for (int i = start; i < n; i++) {
            if (nums[i] == target) {
                result = Math.Abs(i - start);
                break;
            }
        }
        for (int i = start; i >= 0; i--) {
            if (nums[i] == target) {
                result = Math.Min(result, Math.Abs(i - start));
                break;
            }
        }
        return result;
    }
}

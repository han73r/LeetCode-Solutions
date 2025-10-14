public class Solution {
    public bool HasIncreasingSubarrays(IList<int> nums, int k) {
        int n = nums.Count;
        if (n < 2 * k) return false;
        bool IsIncreasing(int start) {
            for (int i = start; i < start + k - 1; i++)
                if (nums[i] >= nums[i + 1]) return false;
            return true;
        }
        for (int i = 0; i <= n - 2 * k; i++) {
            if (IsIncreasing(i) && IsIncreasing(i + k))
                return true;
        }
        return false;
    }
}
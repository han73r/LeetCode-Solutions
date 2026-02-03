public class Solution {
    public bool IsTrionic(int[] nums) {
        int n = nums.Length;
        int peak = n - 1;
        int valley = 0;

        for (int i = 0; i < n - 1; i++) {
            if (peak == n - 1 && nums[i] >= nums[i + 1])
                peak = i;
            if (valley == 0 && nums[n - 1 - i] <= nums[n - 2 - i])
                valley = n - 1 - i;
            if (peak < valley)
                return IsDecreasing(nums, peak, valley);
        }

        return false;
    }

    public bool IsDecreasing(int[] A, int a, int b) {
        if (a == 0 || b == A.Length - 1)
            return false;
        for (int i = a; i < b; i++)
            if (A[i] <= A[i + 1])
                return false;
        return true;
    }
}

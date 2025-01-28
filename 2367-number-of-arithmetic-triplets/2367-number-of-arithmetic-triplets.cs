public class Solution {
    public int ArithmeticTriplets(int[] nums, int diff) {
        int count = 0;
        int n = nums.Length;
        int mid = 1, right = 2;
        // Move left pointer
        for (int left = 0; left < n - 2; left++) {
            // Move mid pointer
            while (mid < n - 1 && nums[mid] - nums[left] < diff)
                mid++;
            if (mid >= n - 1 || nums[mid] - nums[left] > diff) continue;
            // Move right pointer
            while (right < n && nums[right] - nums[mid] < diff)
                right++;
            if (right < n && nums[right] - nums[mid] == diff)
                count++;
        }
        return count;
    }
}
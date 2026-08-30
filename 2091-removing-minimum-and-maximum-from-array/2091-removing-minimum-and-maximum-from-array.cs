public class Solution {
    public int MinimumDeletions(int[] nums) {
        int n = nums.Length;
        if (n == 1) return 1;
        int min = int.MaxValue;
        int max = int.MinValue;
        int minPos = n;
        int maxPos = -1;

        for (int i = 0; i < n; i++) {
            if (nums[i] < min) {
                min = nums[i];
                minPos = i;
            }
            if (nums[i] > max) {
                max = nums[i];
                maxPos = i;
            }
        }

        int left = Math.Min(minPos, maxPos);
        int right = Math.Max(minPos, maxPos);
        int leftDeletes = right + 1;
        int rightDeletes = n - left;
        int bothDeleted = (left + 1) + (n - right);
        
        return Math.Min(
            leftDeletes,
            Math.Min(rightDeletes, bothDeleted)
        );
    }
}

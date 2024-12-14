public class Solution {
    public long ContinuousSubarrays(int[] nums) {
        int left = 0;
        long result = 0;
        int length = nums.Length;
        int[] min = new int[nums.Length];
        int[] max = new int[nums.Length];
        int minidx = 0, maxidx = 0;
        for (int right = 0; right < length; ++right) {
            while (minidx > 0 && nums[min[minidx - 1]] >= nums[right]) {
                minidx--;
            }
            while (maxidx > 0 && nums[max[maxidx - 1]] <= nums[right]) {
                maxidx--;
            }
            min[minidx++] = right;
            max[maxidx++] = right;
            while (nums[max[0]] - nums[min[0]] > 2) {
                left++;
                if (min[0] < left) {
                    Array.Copy(min, 1, min, 0, --minidx);
                }
                if (max[0] < left) {
                    Array.Copy(max, 1, max, 0, --maxidx);
                }
            }
            result += (right - left + 1);
        }
        return result;
    }
}
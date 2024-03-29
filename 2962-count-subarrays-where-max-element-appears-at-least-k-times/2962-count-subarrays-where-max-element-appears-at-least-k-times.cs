using System.Linq;

public class Solution {
    public long CountSubarrays(int[] nums, int k) {
        int maxElement = nums.Max();
        long count = 0;
        int left = 0;
        long result = 0;
        int length = nums.Length;
        for (int right = 0; right < length; right++) {
            if (nums[right] == maxElement) {
                count++;
            }
            while (count >= k) {
                result += length - right;
                if (nums[left] == maxElement) {
                    count--;
                }
                left++;
            }
        }
        return result;
    }
}
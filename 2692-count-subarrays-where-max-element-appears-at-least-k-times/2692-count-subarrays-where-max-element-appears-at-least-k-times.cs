using System.Linq;

public class Solution {
    public long CountSubarrays(int[] nums, int k) {
        int n = nums.Length;
        int maxElement = nums.Max();
        int left = 0;
        long count = 0, result = 0;
        for (int right = 0; right < n; right++) {
            if (nums[right] == maxElement)
                count++;
            while (count >= k) {
                result += n - right;
                if (nums[left] == maxElement)
                    count--;
                left++;
            }
        }
        return result;
    }
}
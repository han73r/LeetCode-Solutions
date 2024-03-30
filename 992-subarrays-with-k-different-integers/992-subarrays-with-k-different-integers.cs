using System.Collections.Generic;

public class Solution {
    public int SubarraysWithKDistinct(int[] nums, int k) {
        Dictionary<int, int> last = new();
        int result = 0;
        int length = nums.Length;
        for (int left = -1, right = 0, temp = 0; right < length; right++) {
            last[nums[right]] = right;
            while (last[nums[temp]] != temp) temp++;
            if (last.Count > k) {
                left = temp++;
                last.Remove(nums[left]);
                while (last[nums[temp]] != temp) temp++;
            }
            if (last.Count == k) result += temp - left;
        }
        return result;
    }
}
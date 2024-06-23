using System.Collections.Generic;
using System;

public class Solution {
    public int LongestSubarray(int[] nums, int limit) {
        int left = 0, right = 0, maxLength = 0;
        var maxDeque = new LinkedList<int>();
        var minDeque = new LinkedList<int>();
        while (right < nums.Length) {
            while (maxDeque.Count > 0 && nums[maxDeque.Last.Value] <= nums[right]) {
                maxDeque.RemoveLast();
            }
            maxDeque.AddLast(right);
            while (minDeque.Count > 0 && nums[minDeque.Last.Value] >= nums[right]) {
                minDeque.RemoveLast();
            }
            minDeque.AddLast(right);
            while (nums[maxDeque.First.Value] - nums[minDeque.First.Value] > limit) {
                left++;
                if (maxDeque.First.Value < left) {
                    maxDeque.RemoveFirst();
                }
                if (minDeque.First.Value < left) {
                    minDeque.RemoveFirst();
                }
            }
            maxLength = Math.Max(maxLength, right - left + 1);
            right++;
        }
        return maxLength;
    }
}
using System.Collections.Generic;

// Sort + 2 pointers. Time: O(n log n). Space: O(1)
// COnvert to List and sort faster than LINQ
public class Solution {
    public int CountPairs(IList<int> nums, int target) {
        if (nums.Count == 1) return 0;
        var numsList = new List<int>(nums);
        numsList.Sort();
        int count = 0;
        int left = 0, right = nums.Count - 1;
        while (left < right) {
            if (numsList[left] + numsList[right] < target) {
                count += (right - left);
                left++;
            } else {
                right--;
            }
        }
        return count;
    }
}
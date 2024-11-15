using System;

public class Solution {
    public int FindLengthOfShortestSubarray(int[] arr) {
        int n = arr.Length;
        int left = 0, right = n - 1;
        while (left < n - 1 && arr[left] <= arr[left + 1]) left++;
        if (left == n - 1) return 0;
        while (right > 0 && arr[right - 1] <= arr[right]) right--;
        int minToRemove = Math.Min(n - left - 1, right);
        int i = 0, j = right;
        while (i <= left && j < n) {
            if (arr[i] <= arr[j]) {
                minToRemove = Math.Min(minToRemove, j - i - 1);
                i++;
            } else {
                j++;
            }
        }
        return minToRemove;
    }
}
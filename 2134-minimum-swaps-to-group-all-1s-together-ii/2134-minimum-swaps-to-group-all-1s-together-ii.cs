using System;

public class Solution {
    public int MinSwaps(int[] nums) {
        int totalOnes = 0;
        // Step 1: Count total number of 1's in the array
        foreach (int num in nums) {
            if (num == 1) totalOnes++;
        }
        if (totalOnes == 0) return 0;

        // Step 2: Use a sliding window approach over the circular array
        int maxOnesInWindow = 0, currentOnesInWindow = 0;
        int n = nums.Length;

        // Step 3: Initialize the first window
        for (int i = 0; i < totalOnes; i++) {
            if (nums[i] == 1) currentOnesInWindow++;
        }
        maxOnesInWindow = currentOnesInWindow;

        // Step 4: Slide the window over the array
        for (int i = 1; i < n; i++) {
            if (nums[i - 1] == 1) currentOnesInWindow--;
            if (nums[(i + totalOnes - 1) % n] == 1) currentOnesInWindow++;
            maxOnesInWindow = Math.Max(maxOnesInWindow, currentOnesInWindow);
        }
        return totalOnes - maxOnesInWindow;
    }
}
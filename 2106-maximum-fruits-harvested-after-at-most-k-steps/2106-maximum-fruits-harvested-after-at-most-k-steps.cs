using System;

public class Solution {
    public int MaxTotalFruits(int[][] fruits, int startPos, int k) {
        int n = fruits.Length;
        int maxFruits = 0;
        int left = 0, total = 0;

        for (int right = 0; right < n; right++) {
            total += fruits[right][1]; // Add fruits in current window

            // Move left pointer to ensure we are within step limit
            while (left <= right && !CanReach(fruits[left][0], fruits[right][0], startPos, k)) {
                total -= fruits[left][1];
                left++;
            }

            maxFruits = Math.Max(maxFruits, total);
        }

        return maxFruits;
    }

    // Function to check if we can reach both ends of the window within k steps
    private bool CanReach(int leftPos, int rightPos, int startPos, int k) {
        // Option 1: Go left first, then to right
        int steps1 = Math.Abs(startPos - leftPos) + (rightPos - leftPos);
        // Option 2: Go right first, then to left
        int steps2 = Math.Abs(startPos - rightPos) + (rightPos - leftPos);
        return Math.Min(steps1, steps2) <= k;
    }
}
using System;

public class Solution {
    public int LargestCombination(int[] candidates) {
        int maxCombinationSize = 0;
        int n = candidates.Length;
        for (int bit = 0; bit < 32; bit++) {
            int mask = 1 << bit;
            int count = 0;
            foreach (int num in candidates) {
                if ((num & mask) > 0) {
                    count++;
                }
            }
            maxCombinationSize = Math.Max(maxCombinationSize, count);
        }
        return maxCombinationSize;
    }
}
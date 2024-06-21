using System;

public class Solution {
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes) {
        int n = customers.Length; int totalSatisfied = 0;
        for (int i = 0; i < n; i++) { if (grumpy[i] == 0) { totalSatisfied += customers[i]; } }
        int additionalSatisfied = 0; int maxAdditionalSatisfied = 0;
        for (int i = 0; i < n; i++) {
            if (grumpy[i] == 1) { additionalSatisfied += customers[i]; }
            if (i >= minutes && grumpy[i - minutes] == 1) { additionalSatisfied -= customers[i - minutes]; }
            maxAdditionalSatisfied = Math.Max(maxAdditionalSatisfied, additionalSatisfied);
        }
        return totalSatisfied + maxAdditionalSatisfied;
    }
}
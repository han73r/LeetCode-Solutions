using System;

public class Solution {
    public int FindKthNumber(int n, int k) {
        int curr = 1;
        k--;
        while (k > 0) {
            long step = CalculateSteps(n, curr, curr + 1);
            if (step <= k) {
                curr++;
                k -= (int)step;
            } else {
                curr *= 10;
                k--;
            }
        }
        return curr;
    }
    private long CalculateSteps(int n, long curr, long next) {
        long steps = 0;
        while (curr <= n) {
            steps += Math.Min(n + 1, next) - curr;
            curr *= 10;
            next *= 10;
        }
        return steps;
    }
}
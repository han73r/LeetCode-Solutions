using System;

public class Solution {
    static int[] memo;
    public int ClimbStairs(int n) {
        memo = new int[n + 1];
        Array.Fill(memo, -1);
        return Climb(n);
    }
    private int Climb(int n) {
        if (n == 0) return 1;
        if (n == 1) return 1;
        if (memo[n] != -1) return memo[n];
        memo[n] = Climb(n - 1) + Climb(n - 2);
        return memo[n];
    }
}
public class Solution {
    public int ClimbStairs(int n) {
        if (n == 0) return 0;
        if (n == 1) return 1;

        int prev1 = 1, prev2 = 2;

        for (int i = 3; i <= n; i++) {
            int result = prev1 + prev2;
            prev1 = prev2;
            prev2 = result;
        }

        return prev2;
    }
}
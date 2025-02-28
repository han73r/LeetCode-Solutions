public class Solution {
    public int ClimbStairs(int n) {
        if (n == 0) return 0;
        if (n == 1) return 1;
        int prev1 = 1, prev2 = 2, temp = 0;
        for (int i = 3; i <= n; i++) {
            temp = prev1 + prev2;
            prev1 = prev2;
            prev2 = temp;
        }
        return prev2;
    }
}
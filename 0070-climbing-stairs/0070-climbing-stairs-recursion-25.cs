public class Solution {
    public int ClimbStairs(int n) {
        if (n == 0) return 1;
        if (n == 1) return 1;
        return (ClimbStairs(n - 1) + ClimbStairs(n - 2));
    }
}
public class Solution {
    public int MaxRotateFunction(int[] nums) {
        long n = nums.Length, sum = 0, f = 0;
        foreach (int x in nums) sum += x;
        for (int i = 0; i < n; i++) f += (long)i * nums[i];
        long maxVal = f;
        for (int i = 1; i < (int)n; i++) {
            f = f + sum - n * nums[(int)n - i];
            if (f > maxVal) maxVal = f;
        }
        return (int)maxVal;
    }
}

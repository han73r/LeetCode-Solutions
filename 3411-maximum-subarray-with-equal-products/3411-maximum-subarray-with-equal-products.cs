
public class Solution {
    public int MaxLength(int[] nums) {
        int n = nums.Length;
        int ans = 0;

        for (int i = 0; i < n; i++) {
            long product = 1;
            long g = 0, l = 1;

            for (int j = i; j < n; j++) {
                product *= nums[j];

                g = GCD(g, nums[j]);
                l = l / GCD(l, nums[j]) * nums[j];

                if (product == g * l) {
                    ans = Math.Max(ans, j - i + 1);
                }
            }
        }

        return ans;
    }

    long GCD(long a, long b) {
        while (b != 0) {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}

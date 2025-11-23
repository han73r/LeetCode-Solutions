public class Solution {
    public int MaxSumDivThree(int[] nums) {
        int sum = nums.Sum();
        int[] m1 = { int.MaxValue, int.MaxValue, int.MaxValue }, m2 = { int.MaxValue, int.MaxValue, int.MaxValue };
        foreach (var x in nums) {
            int r = x % 3;
            if (x < m1[r]) { m2[r] = m1[r]; m1[r] = x; }
            else if (x < m2[r]) m2[r] = x;
        }
        int rem = sum % 3;
        if (rem == 0) return sum;
        int remove = rem == 1
            ? Math.Min(m1[1], m2[2] < int.MaxValue ? m1[2] + m2[2] : int.MaxValue)
            : Math.Min(m1[2], m2[1] < int.MaxValue ? m1[1] + m2[1] : int.MaxValue);
        return remove == int.MaxValue ? 0 : sum - remove;
    }
}

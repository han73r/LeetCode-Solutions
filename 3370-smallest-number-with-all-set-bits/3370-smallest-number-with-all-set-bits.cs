public class Solution {
    public int SmallestNumber(int n) {
        int msb = 31 - System.Numerics.BitOperations.LeadingZeroCount((uint)n);
        int result = (1 << (msb + 1)) - 1;
        return result;
    }
}

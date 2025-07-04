public class Solution {
    public char KthCharacter(long k, int[] operations) {
        ulong mask = 0;
        for (int i = operations.Length - 1; i >= 0; i--)
            mask = (mask << 1) | (ulong) operations[i];
        return (char) ((int) 'a' + BitOperations.PopCount(((ulong) k - 1) & mask) % 26);
    }
}
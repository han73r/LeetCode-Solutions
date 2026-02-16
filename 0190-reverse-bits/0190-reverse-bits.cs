public class Solution {
    public int ReverseBits(int n) {
        for (int i = 0; i < 16; i++) {
            int j = 31 - i;
            int bit_i = (n >> i) & 1;
            int bit_j = (n >> j) & 1;
            if (bit_i != bit_j) {
                n ^= (1 << i);
                n ^= (1 << j);
            }
        }
        return n;
    }
}

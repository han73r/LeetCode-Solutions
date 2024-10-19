public class Solution {
    public char FindKthBit(int n, int k) {
        return FindKthBit(k - 1) ? '1' : '0';
    }
    public bool FindKthBit(int k) {
        if (k == 0)
            return false;
        if (k == 1)
            return true;
        var mask = 0;
        var temp = k;
        while (temp > 0) {
            temp /= 2;
            mask = mask * 2 + 1;
        }
        if (k == mask)
            return true;
        mask /= 2;
        return !FindKthBit(mask - (k - mask));
    }
}
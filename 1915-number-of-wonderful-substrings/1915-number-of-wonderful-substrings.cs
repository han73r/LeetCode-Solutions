public class Solution {
    public long WonderfulSubstrings(string word) {
        long[] freq = new long[1024];
        freq[0] = 1;
        long result = 0;
        int mask = 0;

        foreach (char ch in word) {
            mask ^= MaskOf(ch);
            result += freq[mask];
            for (char curr = 'a'; curr <= 'j'; curr++) {
                int maskToCheck = mask ^ MaskOf(curr);
                result += freq[maskToCheck];
            }
            freq[mask]++;
        }
        return result;
    }

    private int MaskOf(char ch) {
        int val = ch - 'a';
        return 1 << val;
    }
}
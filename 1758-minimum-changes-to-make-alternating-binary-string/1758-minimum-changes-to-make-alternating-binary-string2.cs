public class Solution {
    public int MinOperations(string s) {
        int mismatchStart0 = 0;
        int mismatchStart1 = 0;
        for (int i = 0; i < s.Length; i++) {
            char expected0 = (i % 2 == 0) ? '0' : '1';
            char expected1 = (i % 2 == 0) ? '1' : '0';
            if (s[i] != expected0) mismatchStart0++;
            if (s[i] != expected1) mismatchStart1++;
        }
        return Math.Min(mismatchStart0, mismatchStart1);
    }
}

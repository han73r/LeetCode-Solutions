public class Solution {
    public bool CheckOnesSegment(string s) {
        bool seenZeroAfterOne = false;

        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '1') {
                if (seenZeroAfterOne)
                    return false;
            } else {
                if (i > 0 && s[i - 1] == '1') {
                    seenZeroAfterOne = true;
                }
            }
        }
        return true;
    }
}

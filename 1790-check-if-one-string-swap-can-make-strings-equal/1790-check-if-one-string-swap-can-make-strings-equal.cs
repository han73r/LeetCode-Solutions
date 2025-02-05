public class Solution {
    public bool AreAlmostEqual(string s1, string s2) {
        // If the lengths are different, they cannot be made equal
        if (s1.Length != s2.Length) {
            return false;
        }

        int diffCount = 0;
        int diff1 = -1, diff2 = -1;

        for (int i = 0; i < s1.Length; i++) {
            if (s1[i] != s2[i]) {
                diffCount++;
                if (diffCount == 1) {
                    diff1 = i; // First differing index
                } else if (diffCount == 2) {
                    diff2 = i; // Second differing index
                }
                // If there are more than 2 differences, return false
                if (diffCount > 2) {
                    return false;
                }
            }
        }

        // Evaluate based on the number of differences
        if (diffCount == 0) {
            return true; // Strings are already equal
        } else if (diffCount == 2) {
            // Check if swapping the two differing characters makes the strings equal
            return s1[diff1] == s2[diff2] && s1[diff2] == s2[diff1];
        } else {
            return false; // Only one difference
        }
    }
}
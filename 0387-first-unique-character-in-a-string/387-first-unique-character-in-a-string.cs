public class Solution {
    public int FirstUniqChar(string s) {
        int[] charCount = new int[26];
        foreach (char ch in s) {
            charCount[ch - 'a']++;
        }
        for (int i = 0; i < s.Length; i++) {
            if (charCount[s[i] - 'a'] == 1) {
                return i;
            }
        }
        return -1;
    }
}
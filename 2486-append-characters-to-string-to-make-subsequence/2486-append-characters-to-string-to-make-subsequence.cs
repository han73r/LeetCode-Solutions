public class Solution {
    public int AppendCharacters(string s, string t) {
        int tLength = t.Length;
        int sLength = s.Length;
        int i = 0, j = 0;
        while (i < sLength && j < tLength) {
            if (s[i] == t[j]) {
                j++;
            }
            i++;
        }
        return tLength - j;
    }
}
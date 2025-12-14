public class Solution {
    public int FirstUniqChar(string s) {
        var freq = new Dictionary<char, int>();
        foreach (char c in s) {
            if (freq.ContainsKey(c)) freq[c]++;
            else freq[c] = 1;
        }
        for (int i = 0; i < s.Length; i++) {
            if (freq[s[i]] == 1) return i;
        }
        return -1;
    }
}

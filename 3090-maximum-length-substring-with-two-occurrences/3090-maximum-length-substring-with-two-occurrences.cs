public class Solution {
    public int MaximumLengthSubstring(string s) {
        var charCounter = new Dictionary<char, int>();
        var max = 0;
        var left = 0;
        var n = s.Length;
        for (int i = 0; i < n; i++) {
            if (charCounter.ContainsKey(s[i])) {
                charCounter[s[i]] += 1;
                while (charCounter[s[i]] > 2) {
                    charCounter[s[left]] -= 1;
                    left++;
                }
            } else {
                charCounter[s[i]] = 1;
            }
            max = Math.Max(max, i - left + 1);
        }
        return max;
    }
}

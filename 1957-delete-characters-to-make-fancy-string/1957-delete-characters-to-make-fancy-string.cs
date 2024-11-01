public class Solution {
    public string MakeFancyString(string s) {
        var l = s.Length;
        if (l < 2) { return s; }

        var sb = new StringBuilder();
        sb.Append(s[0]);
        sb.Append(s[1]);

        for (int i = 2; i < l; i++) {
            if (s[i] != sb[sb.Length-1] || s[i] != sb[sb.Length - 2]) {
                sb.Append(s[i]);
            }
        }
        return sb.ToString();
    }
}
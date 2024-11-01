using System.Text;

public class Solution {
    public string MakeFancyString(string s) {
        var l = s.Length;
        if (l < 3) return s;

        var sb = new StringBuilder();
        sb.Append(s[0]);
        sb.Append(s[1]);

        var lastCh = s[1];
        var beforeLastCh = s[0];

        for (int i = 2; i < l; i++) {
            if (s[i] != lastCh || s[i] != beforeLastCh) {
                sb.Append(s[i]);
                beforeLastCh = lastCh;
                lastCh = s[i];
            }
        }
        return sb.ToString();
    }
}
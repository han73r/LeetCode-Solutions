using System.Collections.Generic;

public class Solution {
    public string[] DivideString(string s1, int k, char fill) {
        List<string> result = new List<string>();
        int cnt = 0;
        string s = "";

        foreach (char ch in s1) {
            cnt++;
            s += ch;
            if (cnt == k) {
                result.Add(s);
                s = "";
                cnt = 0;
            }
        }

        if (cnt > 0) {
            while (cnt < k) {
                s += fill;
                cnt++;
            }
            result.Add(s);
        }

        return result.ToArray();
    }
}
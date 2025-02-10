using System.Collections.Generic;
using System;

public class Solution {
    public string ClearDigits(string s) {
        int n = s.Length;
        var st = new Stack<char>();
        for (int i = 0; i < n; i++) {
            if (Char.IsLetter(s[i]))
                st.Push(s[i]);
            else if (st.Count > 0)
                st.Pop();
        }
        return new string(st.Reverse().ToArray());
    }
}
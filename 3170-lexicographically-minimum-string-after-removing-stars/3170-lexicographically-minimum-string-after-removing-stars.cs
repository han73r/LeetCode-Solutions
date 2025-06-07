using System.Collections.Generic;
using System.Text;

public class Solution {
    public string ClearStars(string s) {
        Stack<int>[] charactPos = new Stack<int>[26];
        for (int i = 0; i < 26; i++)
            charactPos[i] = new Stack<int>();
        HashSet<int> mark = new HashSet<int>();
        for (int i = 0; i < s.Length; i++) {
            if (s[i] != '*') {
                charactPos[(int)(s[i] - 'a')].Push(i);
                continue;
            }
            int minCharact = GetMin(charactPos);
            mark.Add(charactPos[minCharact].Pop());
        }
        StringBuilder resultString = new StringBuilder();
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '*' || mark.Contains(i))
                continue;
            resultString.Append(s[i]);
        }
        return resultString.ToString();
    }
    int GetMin(Stack<int>[] charactersPos) {
        for (int i = 0; i < 26; i++) {
            if (charactersPos[i].Any())
                return i;
        }
        return -1;
    }
}
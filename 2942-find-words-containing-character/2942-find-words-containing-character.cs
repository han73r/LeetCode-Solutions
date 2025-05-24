using System.Collections.Generic;

public class Solution {
    public IList<int> FindWordsContaining(string[] words, char x) {
        var res = new List<int>(words.Length);
        for (int i = 0; i < words.Length; ++i) {
            if (words[i].IndexOf(x) >= 0)
                res.Add(i);
        }
        return res;
    }
}
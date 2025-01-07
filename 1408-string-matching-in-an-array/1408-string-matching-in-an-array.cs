using System.Collections.Generic;

public class Solution {
    public IList<string> StringMatching(string[] words) {
        var result = new HashSet<string>();
        var l = words.Length;
        for (int i = 0; i < l; i++) {
            for (int j = 0; j < l; j++) {
                if (i != j && words[j].Contains(words[i])) {
                    result.Add(words[i]);
                    break;
                }
            }
        }
        return result.ToList();
    }
}
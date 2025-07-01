using System.Collections.Generic;

public class Solution {
    public int PossibleStringCount(string word) {
        var n = word.Length;
        var groupLengths = new List<int>();
        int count = 1;
        for (int i = 1; i < word.Length; i++) {
            if (word[i] == word[i - 1]) {
                count++;
            } else {
                groupLengths.Add(count);
                count = 1;
            }
        }
        groupLengths.Add(count);
        int result = 1;
        foreach (int length in groupLengths)
            if (length > 1)
                result += length - 1;
        return result;
    }
}
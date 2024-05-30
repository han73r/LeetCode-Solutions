using System.Collections.Generic;
using System;

public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, List<string>> anagrams = new Dictionary<string, List<string>>();
        foreach (string str in strs) {
            char[] charArray = str.ToCharArray();
            Array.Sort(charArray);
            string sortedStr = new string(charArray);
            if (!anagrams.ContainsKey(sortedStr)) {
                anagrams[sortedStr] = new List<string>();
            }
            anagrams[sortedStr].Add(str);
        }
        return new List<IList<string>>(anagrams.Values);
    }
}
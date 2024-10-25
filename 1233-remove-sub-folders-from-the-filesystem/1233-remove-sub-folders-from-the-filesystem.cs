using System.Collections.Generic;
using System;

public class Solution {
    public IList<string> RemoveSubfolders(string[] folder) {
        Array.Sort(folder);
        IList<string> result = new List<string>();
        result.Add(folder[0]);
        var l = folder.Length;
        for (int i = 1; i < l; i++) {
            string lastFolder = result[result.Count - 1] + "/";
            if (!folder[i].StartsWith(lastFolder)) {
                result.Add(folder[i]);
            }
        }
        return result;
    }
}
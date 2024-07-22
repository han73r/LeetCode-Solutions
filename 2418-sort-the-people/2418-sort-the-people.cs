using System.Collections.Generic;
using System;

public class Solution {
    public string[] SortPeople(string[] names, int[] heights) {
        if (names.Length == 1) return names;
        var peopleHeights = PrepareSortedDictionary(names, heights);
        var result = GetValuesFromDictionary(peopleHeights);
        Array.Reverse(result);
        return result;
    }
    private SortedDictionary<int, string> PrepareSortedDictionary(string[] names, int[] heights) {
        SortedDictionary<int, string> peopleHeights = new SortedDictionary<int, string>();
        for (int i = 0; i < names.Length; i++) {
            peopleHeights.Add(heights[i], names[i]);
        }
        return peopleHeights;
    }
    private string[] GetValuesFromDictionary(SortedDictionary<int, string> sd) {
        string[] result = new string[sd.Count];
        int index = 0;
        foreach (var kvp in sd) {
            result[index++] = kvp.Value;
        }
        return result;
    }
}
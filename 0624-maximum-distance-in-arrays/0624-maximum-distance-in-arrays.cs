using System.Collections.Generic;
using System;

public class Solution {
    public int MaxDistance(IList<IList<int>> arrays) {
        int result = 0;
        int minVal = arrays[0][0];
        int maxVal = arrays[0][arrays[0].Count - 1];
        for (int i = 1; i < arrays.Count; i++) {
            result = Math.Max(result, Math.Max(Math.Abs(arrays[i][arrays[i].Count - 1] - minVal), Math.Abs(maxVal - arrays[i][0])));
            minVal = Math.Min(minVal, arrays[i][0]);
            maxVal = Math.Max(maxVal, arrays[i][arrays[i].Count - 1]);
        }
        return result;
    }
}
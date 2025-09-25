using System.Collections.Generic;
using System;

public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        var n = triangle.Count - 1;
        for (int i = n; i >= 1; i--) {
            for (int y = 0; y < triangle[i - 1].Count; y++) {
                triangle[i - 1][y] = Math.Min(triangle[i - 1][y] + triangle[i][y],
                                            triangle[i - 1][y] + triangle[i][y + 1]);
            }
        }
        return triangle[0][0];
    }
}
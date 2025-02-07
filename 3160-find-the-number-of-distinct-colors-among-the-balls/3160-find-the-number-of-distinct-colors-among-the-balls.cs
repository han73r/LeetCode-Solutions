using System.Collections.Generic;

public class Solution {
    public int[] QueryResults(int limit, int[][] queries) {
        int[] result = new int[queries.Length];
        Dictionary<int, int> ballColor = new(queries.Length), colorCount = new(queries.Length);
        for (int i = 0; i < queries.Length; i++) {
            var q = queries[i];
            int ball = q[0], newColor = q[1], prevColor = ballColor.GetValueOrDefault(ball);
            if (prevColor > 0 && --colorCount[prevColor] == 0) colorCount.Remove(prevColor);
            ballColor[ball] = newColor;
            colorCount[newColor] = colorCount.GetValueOrDefault(newColor) + 1;
            result[i] = colorCount.Count;
        }
        return result;
    }
}
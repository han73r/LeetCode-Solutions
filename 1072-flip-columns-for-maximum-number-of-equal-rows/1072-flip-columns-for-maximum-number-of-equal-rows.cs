using System.Collections.Generic;
using System.Text;

public class Solution {
    public int MaxEqualRowsAfterFlips(int[][] matrix) {
        var rowP = new Dictionary<string, int>();
        foreach (var row in matrix) {
            var pattern = new StringBuilder();
            if (row[0] == 0) {
                foreach (var cell in row) pattern.Append(cell);
            } else {
                foreach (var cell in row) pattern.Append(cell ^ 1);
            }
            var key = pattern.ToString();
            if (!rowP.ContainsKey(key)) rowP[key] = 0;
            rowP[key]++;
        }
        return rowP.Values.Max();
    }
}
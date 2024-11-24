using System;

public class Solution {
    public long MaxMatrixSum(int[][] matrix) {
        int l = matrix.Length;
        int min = int.MaxValue;
        long sum = 0;
        int negativeCount = 0;
        for (int i = 0; i < l; i++) {
            for (int j = 0; j < l; j++) {
                if (matrix[i][j] < 0)
                    negativeCount++;
                int ab = Math.Abs(matrix[i][j]);
                min = Math.Min(min, ab);
                sum += ab;
            }
        }
        if (negativeCount % 2 == 0)
            return sum;
        return sum - 2 * min;
    }
}
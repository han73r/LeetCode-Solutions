using System.Linq;
using System;

public class Solution {
    public int MinimumSum(int[][] A) {
        int res = int.MaxValue;
        for (int rot = 0; rot < 4; rot++) {
            int n = A.Length, m = A[0].Length;
            for (int i = 1; i < n; i++) {
                int a1 = MinimumArea(A.Take(i).ToArray());
                for (int j = 1; j < m; j++) {
                    int[][] part2 = A.Skip(i).Select(r => r.Take(j).ToArray()).ToArray();
                    int[][] part3 = A.Skip(i).Select(r => r.Skip(j).ToArray()).ToArray();
                    int a2 = MinimumArea(part2);
                    int a3 = MinimumArea(part3);
                    res = Math.Min(res, a1 + a2 + a3);
                }
                for (int i2 = i + 1; i2 < n; i2++) {
                    int[][] part2 = A.Skip(i).Take(i2 - i).ToArray();
                    int[][] part3 = A.Skip(i2).ToArray();
                    int a2 = MinimumArea(part2);
                    int a3 = MinimumArea(part3);
                    res = Math.Min(res, a1 + a2 + a3);
                }
            }
            A = Rotate(A);
        }
        return res;
    }

    private int MinimumArea(int[][] A) {
        if (A.Length == 0 || A[0].Length == 0) return 0;
        int n = A.Length, m = A[0].Length;
        int left = int.MaxValue, top = int.MaxValue, right = -1, bottom = -1;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (A[i][j] == 1) {
                    left = Math.Min(left, j);
                    top = Math.Min(top, i);
                    right = Math.Max(right, j);
                    bottom = Math.Max(bottom, i);
                }
            }
        }
        if (right == -1) return 0;
        return (right - left + 1) * (bottom - top + 1);
    }

    private int[][] Rotate(int[][] A) {
        int n = A.Length, m = A[0].Length;
        int[][] rotated = new int[m][];
        for (int i = 0; i < m; i++) rotated[i] = new int[n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                rotated[j][n - 1 - i] = A[i][j];
            }
        }
        return rotated;
    }
}
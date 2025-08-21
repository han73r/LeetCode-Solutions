using System.Collections.Generic;

public class Solution {
    public int NumSubmat(int[][] mat) {
        int r = mat.Length, c = mat[0].Length, ans = 0;
        int[] h = new int[c];
        for (int i = 0; i < r; i++) {
            for (int j = 0; j < c; j++)
                h[j] = (mat[i][j] == 0) ? 0 : h[j] + 1;

            int[] sum = new int[c];
            Stack<int> st = new Stack<int>();
            for (int j = 0; j < c; j++) {
                while (st.Count > 0 && h[st.Peek()] >= h[j]) st.Pop();
                if (st.Count > 0) {
                    int p = st.Peek();
                    sum[j] = sum[p] + h[j] * (j - p);
                } else {
                    sum[j] = h[j] * (j + 1);
                }
                st.Push(j);
                ans += sum[j];
            }
        }
        return ans;
    }
}
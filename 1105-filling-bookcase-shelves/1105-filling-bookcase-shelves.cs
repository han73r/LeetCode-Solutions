using System;

public class Solution {
    int[] dp;
    int length;
    public int MinHeightShelves(int[][] books, int shelfWidth) {
        length = books.Length;
        dp = new int[length + 1];
        Array.Fill(dp, int.MaxValue);
        return DFS(books, shelfWidth, 0);
    }
    private int DFS(int[][] books, int shelfWidth, int index) {
        if (index >= length) return 0;
        if (dp[index] != int.MaxValue) return dp[index];
        int width = 0, i = index, maxHeight = books[i][1];
        while (i < length && width < shelfWidth) {
            width += books[i][0];
            maxHeight = Math.Max(maxHeight, books[i][1]);
            if (width <= shelfWidth) {
                dp[index] = Math.Min(dp[index], maxHeight + DFS(books, shelfWidth, i + 1));
            }
            i++;
        }
        return dp[index];
    }
}
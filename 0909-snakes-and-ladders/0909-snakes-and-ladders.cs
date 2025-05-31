using System.Collections.Generic;

public class Solution {
    public int SnakesAndLadders(int[][] board) {
        int n = board.Length;
        bool[] visited = new bool[n * n + 1];
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        visited[1] = true;
        int moves = 0;
        while (queue.Count > 0) {
            int size = queue.Count;
            for (int i = 0; i < size; i++) {
                int curr = queue.Dequeue();
                if (curr == n * n) return moves;
                for (int dice = 1; dice <= 6; dice++) {
                    int next = curr + dice;
                    if (next > n * n) continue;
                    (int r, int c) = GetCoordinates(next, n);
                    if (board[r][c] != -1)
                        next = board[r][c];
                    if (!visited[next]) {
                        visited[next] = true;
                        queue.Enqueue(next);
                    }
                }
            }
            moves++;
        }
        return -1;
    }
    private (int, int) GetCoordinates(int pos, int n) {
        int row = (pos - 1) / n;
        int col = (pos - 1) % n;
        if (row % 2 == 1) col = n - 1 - col;
        return (n - 1 - row, col);
    }
}
public class Solution {
    public int DeleteGreatestValue(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        int total = 0;

        var rowPQs = new PriorityQueue<int,int>[m];
        for (int i = 0; i < m; i++) {
            rowPQs[i] = new PriorityQueue<int,int>();
            foreach (int val in grid[i])
                rowPQs[i].Enqueue(val, -val);
        }

        for (int col = 0; col < n; col++) {
            int maxInColumn = int.MinValue;
            for (int row = 0; row < m; row++) {
                if (rowPQs[row].Count > 0) {
                    int current = rowPQs[row].Dequeue();
                    maxInColumn = Math.Max(maxInColumn, current);
                }
            }
            total += maxInColumn;
        }
        return total;
    }
}

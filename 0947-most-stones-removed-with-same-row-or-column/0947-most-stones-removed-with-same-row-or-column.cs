public class Solution {
    public int RemoveStones(int[][] stones) {
        int n = stones.Length;
        bool[] visited = new bool[n];
        int numOfComponents = 0;
        for (int i = 0; i < n; i++) {
            if (!visited[i]) {
                DFS(stones, visited, i);
                numOfComponents++;
            }
        }
        return n - numOfComponents;
    }
    private void DFS(int[][] stones, bool[] visited, int index) {
        visited[index] = true;
        for (int i = 0; i < stones.Length; i++) {
            if (!visited[i] && (stones[i][0] == stones[index][0] || stones[i][1] == stones[index][1])) {
                DFS(stones, visited, i);
            }
        }
    }
}

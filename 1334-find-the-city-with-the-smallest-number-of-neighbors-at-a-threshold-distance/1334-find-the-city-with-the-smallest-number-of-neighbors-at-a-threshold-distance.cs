public class Solution {
    public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
        int[,] dist = InitializeDistances(n, edges);
        FloydWarshall(n, dist);
        return FindCityWithMinReachableCities(n, dist, distanceThreshold);
    }

    private int[,] InitializeDistances(int n, int[][] edges) {
        int[,] dist = new int[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                dist[i, j] = i == j ? 0 : int.MaxValue / 2;
        foreach (var edge in edges) {
            int u = edge[0], v = edge[1], w = edge[2];
            dist[u, v] = w;
            dist[v, u] = w;
        }
        return dist;
    }

    private void FloydWarshall(int n, int[,] dist) {
        for (int k = 0; k < n; k++)
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (dist[i, j] > dist[i, k] + dist[k, j])
                        dist[i, j] = dist[i, k] + dist[k, j];
    }

    private int FindCityWithMinReachableCities(int n, int[,] dist, int distanceThreshold) {
        int minReachableCities = int.MaxValue;
        int cityWithMinReachableCities = -1;
        for (int i = 0; i < n; i++) {
            int reachableCities = 0;
            for (int j = 0; j < n; j++) {
                if (i != j && dist[i, j] <= distanceThreshold)
                    reachableCities++;
            }
            if (reachableCities <= minReachableCities) {
                minReachableCities = reachableCities;
                cityWithMinReachableCities = i;
            }
        }
        return cityWithMinReachableCities;
    }
}

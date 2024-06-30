public class UnionFind {
    private int[] parent;
    private int[] rank;
    public UnionFind(int size) {
        parent = new int[size];
        rank = new int[size];
        for (int i = 0; i < size; i++) {
            parent[i] = i;
            rank[i] = 1;
        }
    }
    public int Find(int x) {
        if (parent[x] != x) {
            parent[x] = Find(parent[x]);
        }
        return parent[x];
    }
    public bool Union(int x, int y) {
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX == rootY) {
            return false;
        }
        if (rank[rootX] > rank[rootY]) {
            parent[rootY] = rootX;
        } else if (rank[rootX] < rank[rootY]) {
            parent[rootX] = rootY;
        } else {
            parent[rootY] = rootX;
            rank[rootX]++;
        }

        return true;
    }
}
public class Solution {
    public int MaxNumEdgesToRemove(int n, int[][] edges) {
        UnionFind ufAlice = new UnionFind(n + 1);
        UnionFind ufBob = new UnionFind(n + 1);
        int edgesUsed = 0;
        foreach (var edge in edges) {
            if (edge[0] == 3) {
                if (ufAlice.Union(edge[1], edge[2]) | ufBob.Union(edge[1], edge[2])) {
                    edgesUsed++;
                }
            }
        }
        foreach (var edge in edges) {
            if (edge[0] == 1) {
                if (ufAlice.Union(edge[1], edge[2])) {
                    edgesUsed++;
                }
            } else if (edge[0] == 2) {
                if (ufBob.Union(edge[1], edge[2])) {
                    edgesUsed++;
                }
            }
        }
        if (IsConnected(ufAlice, n) && IsConnected(ufBob, n)) {
            return edges.Length - edgesUsed;
        } else {
            return -1;
        }
    }
    private bool IsConnected(UnionFind uf, int n) {
        int root = uf.Find(1);
        for (int i = 2; i <= n; i++) {
            if (uf.Find(i) != root) {
                return false;
            }
        }
        return true;
    }
}
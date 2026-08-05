public class Solution {
    public IList<int> RemainingMethods(int n, int k, int[][] invocations) {
        List<int>[] graph = BuildGraph(n, invocations);
        bool[] isSuspicious = FindSuspiciousMethods(n, k, graph);

        if (HasExternalInvocation(invocations, isSuspicious)) {
            List<int> allMethods = new List<int>();
            for (int i = 0; i < n; i++) allMethods.Add(i);
            return allMethods;
        }

        List<int> result = new List<int>();
        for (int i = 0; i < n; i++) {
            if (!isSuspicious[i]) {
                result.Add(i);
            }
        }

        return result;
    }

    private List<int>[] BuildGraph(int n, int[][] invocations) {
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++) {
            graph[i] = new List<int>();
        }
        foreach (var inv in invocations) {
            graph[inv[0]].Add(inv[1]);
        }
        return graph;
    }

    private bool[] FindSuspiciousMethods(int n, int k, List<int>[] graph) {
        bool[] isSuspicious = new bool[n];
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(k);
        isSuspicious[k] = true;

        while (queue.Count > 0) {
            int curr = queue.Dequeue();
            foreach (int neighbor in graph[curr]) {
                if (!isSuspicious[neighbor]) {
                    isSuspicious[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
        return isSuspicious;
    }

    private bool HasExternalInvocation(int[][] invocations, bool[] isSuspicious) {
        foreach (var inv in invocations) {
            int u = inv[0];
            int v = inv[1];
            if (!isSuspicious[u] && isSuspicious[v]) {
                return true;
            }
        }
        return false;
    }
}

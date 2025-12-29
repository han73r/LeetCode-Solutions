public class Solution {
private Dictionary<string, List<char>> map = new Dictionary<string, List<char>>();
    public bool PyramidTransition(string bottom, IList<string> allowed) {
        foreach (string s in allowed) {
            string key = s.Substring(0, 2);
            char top = s[2];

            if (!map.ContainsKey(key)) {
                map[key] = new List<char>();
            }
            map[key].Add(top);
        }

        // Start DFS from bottom row
        return Dfs(bottom);
    }
    private bool Dfs(string bottom) {
        // Base case: pyramid completed
        if (bottom.Length == 1) {
            return true;
        }

        // Generate all possible next rows
        List<string> nextRows = new List<string>();
        BuildNextRows(bottom, 0, new StringBuilder(), nextRows);

        // Try each possible next row
        foreach (string next in nextRows) {
            if (Dfs(next)) {
                return true;
            }
        }

        return false;
    }

    private void BuildNextRows(string bottom, int index,
                               StringBuilder current, List<string> result) {
        // If a full next row is built
        if (index == bottom.Length - 1) {
            result.Add(current.ToString());
            return;
        }

        string key = bottom.Substring(index, 2);

        // If no valid triangle can be formed
        if (!map.ContainsKey(key)) {
            return;
        }

        // Try all possible top blocks
        foreach (char c in map[key]) {
            current.Append(c);
            BuildNextRows(bottom, index + 1, current, result);
            current.Length--; // backtrack
        }
    }
}

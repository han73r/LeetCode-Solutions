public class Solution 
{
    public int[] RestoreArray(int[][] adjacentPairs) 
    {
        var adjancyDict = new Dictionary<int, List<int>>();
        List<int> result = new List<int>();
        HashSet<int> visited = new HashSet<int>();
        int startNode = 0;

        foreach (var pair in adjacentPairs)
        {
            if (!adjancyDict.ContainsKey(pair[0]))
                adjancyDict[pair[0]] = new List<int>();
            if (!adjancyDict.ContainsKey(pair[1]))
                adjancyDict[pair[1]] = new List<int>();

            adjancyDict[pair[0]].Add(pair[1]);
            adjancyDict[pair[1]].Add(pair[0]);
        }
        foreach (var node in adjancyDict)
        {
            if (node.Value.Count == 1)
            {
                startNode = node.Key;
                break;
            }
        }       
        BuildSequence(adjancyDict, startNode, visited, result);
        return result.ToArray();
    }

    private void BuildSequence(Dictionary<int, List<int>> dict, int node, HashSet<int> visited, List<int> result)
    {
        visited.Add(node);
        result.Add(node);

        foreach (var neighbor in dict[node])
        {
            if (!visited.Contains(neighbor))
            {
                BuildSequence(dict, neighbor, visited, result);
            }
        }
    }
}
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
            
        Stack<int> stack = new Stack<int>();
        stack.Push(startNode);

        while (stack.Count > 0)
        {
            int node = stack.Pop();

            if (!visited.Contains(node))
            {
                visited.Add(node);
                result.Add(node);

                foreach (var neighbor in adjancyDict[node])
                {
                    if (!visited.Contains(neighbor))
                    {
                        stack.Push(neighbor);
                    }
                }
            }
        }
        return result.ToArray();
    }
}
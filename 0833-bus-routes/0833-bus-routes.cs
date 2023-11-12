public class Solution 
{
    public int NumBusesToDestination(int[][] routes, int source, int target) 
    {
        if (source == target)
        return 0;

    Dictionary<int, List<int>> stopToRoutes = new Dictionary<int, List<int>>();
    for (int bus = 0; bus < routes.Length; bus++)
    {
        foreach (int stop in routes[bus])
        {
            if (!stopToRoutes.ContainsKey(stop))
                stopToRoutes[stop] = new List<int>();
            stopToRoutes[stop].Add(bus);
        }
    }

    HashSet<int> visitedBuses = new HashSet<int>();
    HashSet<int> visitedStops = new HashSet<int>();
    Queue<int> queue = new Queue<int>();

    queue.Enqueue(source);
    int level = 0;

    while (queue.Count > 0)
    {
        int stopsAtThisLevel = queue.Count;

        for (int i = 0; i < stopsAtThisLevel; i++)
        {
            int currentStop = queue.Dequeue();

            foreach (int bus in stopToRoutes[currentStop])
            {
                if (visitedBuses.Contains(bus))
                    continue;

                visitedBuses.Add(bus);

                foreach (int nextStop in routes[bus])
                {
                    if (visitedStops.Contains(nextStop))
                        continue;

                    visitedStops.Add(nextStop);

                    if (nextStop == target)
                        return level + 1;

                    queue.Enqueue(nextStop);
                }
            }
        }

        level++;
    }
    return -1;
    }
}
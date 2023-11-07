public class Solution 
{
    public int EliminateMaximum(int[] dist, int[] speed) 
    {
        int n = dist.Length;
        int[] arrivalTime = new int[n];

        for (int i = 0; i < n; i++)
        {
            arrivalTime[i] = (dist[i] - 1) / speed[i];
        }

        Array.Sort(arrivalTime);

        for (int i = 0; i < n; i++)
        {
            if (i > arrivalTime[i])
            {
                return i;
            }
        }
        return n;
    }
}
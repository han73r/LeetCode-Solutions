public class Solution
{
    public int MinTimeToVisitAllPoints(int[][] points)
    {
        int totalTime = 0;
        for (int i = 1; i < points.Length; i++)
        {
            int xDiff = Math.Abs(points[i][0] - points[i - 1][0]);
            int yDiff = Math.Abs(points[i][1] - points[i - 1][1]);
            totalTime += Math.Max(xDiff, yDiff);
        }
        return totalTime;
    }
}
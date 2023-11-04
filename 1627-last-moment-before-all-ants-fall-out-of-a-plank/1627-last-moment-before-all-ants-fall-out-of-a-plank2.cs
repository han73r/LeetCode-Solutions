public class Solution 
{
    public int GetLastMoment(int n, int[] left, int[] right) 
    {
        return Math.Max(left.Length > 0 ? left.Max() : 0, right.Length > 0 ? n - right.Min() : 0);
    }
}

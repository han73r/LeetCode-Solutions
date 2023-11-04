public class Solution 
{
    public int GetLastMoment(int n, int[] left, int[] right) 
    {
        if (left.Length == 0 && right.Length == 0 || left == null && right == null)
        {
            return 0;
        }

        if (left.Length != 0)
        {
            int maxGoLeftTime = left.Max();

            if (right.Length != 0)
            {
                int maxGoRightTime = n - right.Min();
                if (true)
                {
                    return Math.Max(maxGoRightTime, maxGoLeftTime);
                }
            }
            else
            {
                return maxGoLeftTime;
            }
        }
        else
        {
            return n - right.Min();
        }
    }
}